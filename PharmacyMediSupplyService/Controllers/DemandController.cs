using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
    public class DemandController : ControllerBase
    {
        IDemandRepo demandRepo;
        PharmacySupplyContext context = new();
        public DemandController(IDemandRepo demdrepo)
        {
            demandRepo = demdrepo;
        }
        [HttpGet]
        public async Task<ActionResult<List<Demand>>> GetAllDemands()
        {
            List<Demand> demands = await demandRepo.GetAllDemands();
            return Ok(demands);
        }
        [HttpGet("{dmndId}")]
        public async Task<ActionResult<Demand>> GetOne(string dmndId)
        {
            try
            {
                Demand demand = await demandRepo.GetDemandById(dmndId);
                return Ok(demand);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("GetByMediID/{medId}")]
        public async Task<ActionResult<List<Demand>>> GetDemandByMediId(string medId)
        {
            try
            {
                List<Demand> demands = await demandRepo.GetDemandByMedicineId(medId);
                return demands;
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        /*private void PublishToMessageQueue(string integrationEvent, string eventData)
        {
            var factory = new ConnectionFactory();
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            var body = Encoding.UTF8.GetBytes(eventData);
            channel.BasicPublish(exchange: "demand", routingKey: integrationEvent, basicProperties: null, body: body);
        }*/
        [HttpPost]
        public async Task<ActionResult<Demand>> Insert(Demand demand)
        {
     
            await demandRepo.CreateDemand(demand);
            /*var integrationEventData = JsonConvert.SerializeObject(new { DemandId = demand.DemandId });
            PublishToMessageQueue("demand.add", integrationEventData);*/
            return Ok();

        }
        [HttpPut("{dmndId}")]
        public async Task<ActionResult> Update(string dmndId, Demand demand)
        {
            await demandRepo.UpdateDemand(dmndId, demand);
            return Ok();
        }
        [HttpDelete("{dmndId}")]
        public async Task<ActionResult> Delete(string dmndId)
        {
            await demandRepo.DeleteDemand(dmndId);
            /*var integrationEventData = JsonConvert.SerializeObject(new { DemandId = dmndId });
            PublishToMessageQueue("demand.delete", integrationEventData);*/
            return Ok();
        }
    }

}