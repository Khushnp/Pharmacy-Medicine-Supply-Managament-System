using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PharmacyMediSupplyRepository.Dtos;
using PharmacyMediSupplyRepository.Models;
using PharmacyMediSupplyRepository.Repos;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PharmacyMediSupplyService.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class MedicineSupplyController : ControllerBase
    {
        IMedicineSupplyRepo medicineSupplyRepo;
        public MedicineSupplyController(IMedicineSupplyRepo medSupplyRepo)
        {
            medicineSupplyRepo = medSupplyRepo;
        }
        [HttpGet]
        public async Task<ActionResult<List<MedicineSupply>>> GetAll()
        {
            List<MedicineSupply> medicineSupplies = await medicineSupplyRepo.GetAllMedicinesSupply();
            return Ok(medicineSupplies);
        }

        [HttpGet("{medsplyId}")]
        public async Task<ActionResult<MedicineSupplyDto>> GetOne(string medsplyId)
        {
           
            try
            {
                MedicineSupply medicineSupply = await medicineSupplyRepo.GetMedicineById(medsplyId);
                return Ok(medicineSupply.AsDto());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("GetByPharmacy")]
        public async Task<ActionResult<List<MedicineSupply>>> GetMedicineByPharmacyId(string pharmaId)
        {
            try
            {
                List<MedicineSupply> medicineSupplies = await medicineSupplyRepo.GetMedicineByPharmacyId(pharmaId);
                return Ok(medicineSupplies);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        private void PublishToMessageQueue(string integrationEvent, string eventData)
        {
            var factory = new ConnectionFactory();
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            var body = Encoding.UTF8.GetBytes(eventData);
            channel.BasicPublish(exchange: "medicineSupply", routingKey: integrationEvent, basicProperties: null, body: body);
        }

        [HttpPost]
        public async Task<ActionResult<MedicineSupply>> InsertMedicine(MedicineSupply medsply)
        {
            await medicineSupplyRepo.InsertMedicine(medsply);
            var integrationEventData = JsonConvert.SerializeObject(new { MedicineSupplyId = medsply.MedicineSupplyId });
            PublishToMessageQueue("medsply.add", integrationEventData);
            return Ok();
        }

        /*[HttpPut("{medsplyId}")]
        public async Task<ActionResult> UpdateMedicine(string medsplyId, MedicineSupply medsply)
        {
            await medicineSupplyRepo.UpdateMedicine(medsplyId, medsply);
            return Ok();
        }*/

        [HttpDelete("{medsplyId}")]
        public async Task<ActionResult> DeleteMedicine(string medsplyId)
        {
            await medicineSupplyRepo.DeleteMedicine(medsplyId);
            var integrationEventData = JsonConvert.SerializeObject(new { MedicineSupplyId = medsplyId });
            PublishToMessageQueue("medsply.delete", integrationEventData);
            return Ok();
        }

    }
}
