using MedicineRepScheduleRepository.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PMSMS_MvcApp.Controllers
{
    [Authorize]
    public class MedicalRepScheduleController : Controller
    {
        HttpClient client;
        public MedicalRepScheduleController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9000/MedicalRepScheduleSvc/");
        }
        /*[Route("MedicalRepSchedule/GetAllSchedules")]*/

        public async Task<ActionResult> Index()
        {
            string userName = User.Identity.Name;
            string roleName = User.Claims.ToArray()[4].Value;
            string token = await client.GetStringAsync("http://localhost:9000/AuthSvc/?userName=" + userName + "&role=" + roleName + "&key=My name is James Bond");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            List<Schedule> schedules = await client.GetFromJsonAsync<List<Schedule>>("");
            return View(schedules);
        }
        [Route("MedicalRepSchedule/GetOne/{schdlId}")]
        public async Task<ActionResult> Details(string schdlId)
        {
            string userName = User.Identity.Name;
            string roleName = User.Claims.ToArray()[4].Value;
            string token = await client.GetStringAsync("http://localhost:9000/AuthSvc/?userName=" + userName + "&role=" + roleName + "&key=My name is James Bond");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            Schedule schedule = await client.GetFromJsonAsync<Schedule>("GetScheduleById/" + schdlId);
            return View(schedule);
        }

        [Route("MedicalRepSchedule/GetAllByMediRepId/{medrepId}")]
        public async Task<ActionResult> SchedulesByMediRep(string medrepId)
        {
            string userName = User.Identity.Name;
            string roleName = User.Claims.ToArray()[4].Value;
            string token = await client.GetStringAsync("http://localhost:9000/AuthSvc/?userName=" + userName + "&role=" + roleName + "&key=My name is James Bond");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            List<Schedule> schedule = await client.GetFromJsonAsync<List<Schedule>>("GetSchedulesByMedicalRepId/" + medrepId);
            return View(schedule);
        }

        [Route("MedicalRepSchedule/GetAllByDocId/{docId}")]
        public async Task<ActionResult> SchedulesByDoctor(string docId)
        {
            string userName = User.Identity.Name;
            string roleName = User.Claims.ToArray()[4].Value;
            string token = await client.GetStringAsync("http://localhost:9000/AuthSvc/?userName=" + userName + "&role=" + roleName + "&key=My name is James Bond");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            List<Schedule> schedule = await client.GetFromJsonAsync<List<Schedule>>("GetSchedulesByDoctorId/" + docId);
            return View(schedule);
        }

        [Route("MedicalRepSchedule/GetAllByMediId/{medId}")]
        public async Task<ActionResult> SchedulesByMedicine(string medId)
        {
            string userName = User.Identity.Name;
            string roleName = User.Claims.ToArray()[4].Value;
            string token = await client.GetStringAsync("http://localhost:9000/AuthSvc/?userName=" + userName + "&role=" + roleName + "&key=My name is James Bond");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            List<Schedule> schedule = await client.GetFromJsonAsync<List<Schedule>>("GetSchedulesByMedicineId/" + medId);
            return View(schedule);
        }

        /*[Route("MedicalRepSchedule/Insert/")]*/
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        /*[Route("MedicalRepSchedule/Insert/")]*/
        public async Task<ActionResult> Create(Schedule schedule)
        {
            string userName = User.Identity.Name;
            string roleName = User.Claims.ToArray()[4].Value;
            string token = await client.GetStringAsync("http://localhost:9000/AuthSvc/?userName=" + userName + "&role=" + roleName + "&key=My name is James Bond");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            try
            {
                await client.PostAsJsonAsync<Schedule>("", schedule);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }


        [Route("MedicalRepSchedule/Update/{schdlId}")]
        public async Task<ActionResult> Edit(string schdlId)
        {
            string userName = User.Identity.Name;
            string roleName = User.Claims.ToArray()[4].Value;
            string token = await client.GetStringAsync("http://localhost:9000/AuthSvc/?userName=" + userName + "&role=" + roleName + "&key=My name is James Bond");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            Schedule schedule = await client.GetFromJsonAsync<Schedule>("GetScheduleById/" + schdlId);
            return View(schedule);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("MedicalRepSchedule/Update/{schdlId}")]
        public async Task<ActionResult> Edit(string schdlId, Schedule schedule)
        {
            string userName = User.Identity.Name;
            string roleName = User.Claims.ToArray()[4].Value;
            string token = await client.GetStringAsync("http://localhost:9000/AuthSvc/?userName=" + userName + "&role=" + roleName + "&key=My name is James Bond");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            try
            {
                await client.PutAsJsonAsync<Schedule>(schdlId, schedule);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [Route("MedicalRepSchedule/Delete/{schdlId}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Delete(string schdlId)
        {

            string userName = User.Identity.Name;
            string roleName = User.Claims.ToArray()[4].Value;
            string token = await client.GetStringAsync("http://localhost:9000/AuthSvc/?userName=" + userName + "&role=" + roleName + "&key=My name is James Bond");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            
            Schedule schedule = await client.GetFromJsonAsync<Schedule>("GetScheduleById/" + schdlId);
            return View(schedule);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("MedicalRepSchedule/Delete/{schdlId}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Delete(string schdlId, IFormCollection collection)
        {
            string userName = User.Identity.Name;
            string roleName = User.Claims.ToArray()[4].Value;
            string token = await client.GetStringAsync("http://localhost:9000/AuthSvc/?userName=" + userName + "&role=" + roleName + "&key=My name is James Bond");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            try
            {
                await client.DeleteAsync(schdlId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}











/*
        //Trying to get all doctors list---------------------------------------------------------------------->
        public async Task<ActionResult> GetAllDoctors()
        {
            string userName = User.Identity.Name;
            string roleName = User.Claims.ToArray()[4].Value;
            string token = await client.GetStringAsync("http://localhost:9000/AuthSvc/?userName=" + userName + "&role=" + roleName + "&key=My name is James Bond");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            List<Doctor> d = await client.GetFromJsonAsync<List<Doctor>>("");
            return View(d);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        *//*[Route("MedicalRepSchedule/Insert/")]*//*
        public async Task<ActionResult> CreateDoctor(Doctor doctor)
        {
            string userName = User.Identity.Name;
            string roleName = User.Claims.ToArray()[4].Value;
            string token = await client.GetStringAsync("http://localhost:9000/AuthSvc/?userName=" + userName + "&role=" + roleName + "&key=My name is James Bond");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            try
            {
                await client.PostAsJsonAsync<Doctor>("", doctor);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }
*/