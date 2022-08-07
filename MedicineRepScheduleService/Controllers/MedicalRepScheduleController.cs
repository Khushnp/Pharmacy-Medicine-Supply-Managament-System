using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using Newtonsoft.Json;
using MedicineRepScheduleRepository.Repos;
using MedicineRepScheduleRepository.Models;
using Microsoft.AspNetCore.Authorization;

namespace MedicineRepScheduleService.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class MedicalRepScheduleController : ControllerBase
    {
        IMedicalRepScheduleRepo medicalRepScheduleRepo;

        public MedicalRepScheduleController(IMedicalRepScheduleRepo medrep)
        {
            medicalRepScheduleRepo = medrep;
        }

       
        [HttpGet]
        public async Task<ActionResult<List<Schedule>>> GetAllSchedules()
        {
            List<Schedule> schedules = await medicalRepScheduleRepo.GetAllSchedules();
            return Ok(schedules);
        }
        [HttpGet("GetScheduleById/{schdlId}")]
        public async Task<ActionResult<Schedule>> GetOne(string schdlId)
        {
            try
            {
                Schedule schedule = await medicalRepScheduleRepo.GetScheduleById(schdlId);
                return Ok(schedule);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("GetSchedulesByMedicalRepId/{medrepId}")]
        public async Task<ActionResult<List <Schedule>>> GetAllByMediRepId(string medrepId)
        {
            try
            {
                List<Schedule> schedules = await medicalRepScheduleRepo.GetSchedulesByMedicalRepId(medrepId);
                return Ok(schedules);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("GetSchedulesByDoctorId/{docId}")]
        public async Task<ActionResult<List<Schedule>>> GetAllByDocId(string docId)
        {
            try
            {
                List<Schedule> schedules = await medicalRepScheduleRepo.GetSchedulesByDoctorId(docId);
                return Ok(schedules);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("GetSchedulesByMedicineId/{medId}")]
        public async Task<ActionResult<List<Schedule>>> GetAllByMediId(string medId)
        {
            try
            {
                List<Schedule> schedules = await medicalRepScheduleRepo.GetSchedulesByMedicineId(medId);
                return Ok(schedules);
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
            channel.BasicPublish(exchange: "schedule", routingKey: integrationEvent, basicProperties: null, body: body);
        }
        [HttpPost]
        public async Task<ActionResult<Schedule>> Insert(Schedule schedule)
        {
            await medicalRepScheduleRepo.CreateSchedule(schedule);
            var integrationEventData = JsonConvert.SerializeObject(new { ScheduleId = schedule.ScheduleId });
            PublishToMessageQueue("schedule.add", integrationEventData);
            return Created($"api/schedule/{schedule.ScheduleId}", schedule);

        }
        [HttpPut("{schdlId}")]
        public async Task<ActionResult> Update(string schdlId, Schedule schedule)
        {
            await medicalRepScheduleRepo.UpdateSchedule(schdlId, schedule);
            return Ok();
        }
        [HttpDelete("{schdlId}")]
        public async Task<ActionResult> Delete(string schdlId)
        {
            await medicalRepScheduleRepo.DeleteSchedule(schdlId);
            var integrationEventData = JsonConvert.SerializeObject(new { ScheduleId = schdlId });
            PublishToMessageQueue("schedule.delete", integrationEventData);
            return Ok();
        }

    }
}


/* //trying to get all the doctor list 
        [HttpGet ("GetAllDoctors")]
        public async Task<ActionResult<List<Schedule>>> GetAllDoctors()
        {
            List<Doctor> d = await medicalRepScheduleRepo.GetAllDoctors();
            return Ok(d);
        }
        [HttpPost ("CreateDoctor")]
        public async Task<ActionResult<Schedule>> CreateDoctor(Doctor doctor)
        {
            await medicalRepScheduleRepo.CreateDoctor(doctor);
            *//*var integrationEventData = JsonConvert.SerializeObject(new { ScheduleId = schedule.ScheduleId });
            PublishToMessageQueue("schedule.add", integrationEventData);*//*
            return Created($"api/schedule/{doctor.DoctorId}",doctor);

        }
*/