using MedicineStockRepository.Models;
using MedicineStockRepository.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineStockService.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    
    public class MedicineStockController : ControllerBase
    {
        readonly IMedicineStockRepo medicineStockRepo;
        public MedicineStockController(IMedicineStockRepo medstk)
        {
            medicineStockRepo = medstk;
        }
        [HttpGet]
        public async Task<ActionResult<List<MedicineStock>>> GetAll()
        {
            List<MedicineStock> medicineStocks = await medicineStockRepo.GetAllMedicine();
            return Ok(medicineStocks);
        }

        [HttpGet("{MedicineId}")]
        public async Task<ActionResult<MedicineStock>> GetOne(string MedicineId)
        {
            try
            {
                MedicineStock medicineStock = await medicineStockRepo.GetMedicineById(MedicineId);
                return Ok(medicineStock);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        private void PublishToMessageQueue(string integrationEvent, string eventData)
        {
            var factory = new ConnectionFactory();
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            var body = Encoding.UTF8.GetBytes(eventData);
            channel.BasicPublish(exchange: "medicine", routingKey: integrationEvent, basicProperties: null, body: body);
        }

        [HttpPost]
        public async Task<ActionResult<MedicineStock>> Insert(MedicineStock medicine)
        {
            await medicineStockRepo.InsertMedicine(medicine);
            var integrationEventData = JsonConvert.SerializeObject(new 
            {   MedicineId = medicine.MedicineId , 
                MedicineName = medicine.MedicineName , 
                NumberOfTabletsInStock = medicine.NumberOfTabletsInStock 
            });
            PublishToMessageQueue("MedicineStock.add", integrationEventData);
            return Ok();
        }

        [HttpPut("{MedicineId}")]
        public async Task<ActionResult> Update(string MedicineId, MedicineStock medicine)
        {
            await medicineStockRepo.UpdateMedicine(MedicineId, medicine);
            return Ok();
        }

        [HttpDelete("{MedicineId}")]
        public async Task<ActionResult> Delete(string MedicineId)
        {
            await medicineStockRepo.DeleteMedicine(MedicineId);
            var integrationEventData = JsonConvert.SerializeObject(new { MedicineId = MedicineId });
            PublishToMessageQueue("MedicineStock.delete", integrationEventData);

            return Ok();
        }
    }
}
