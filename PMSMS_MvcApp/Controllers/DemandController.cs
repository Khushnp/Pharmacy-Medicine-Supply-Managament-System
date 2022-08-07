using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyMediSupplyRepository.Models;
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
    public class DemandController : Controller
    {
        HttpClient client;
        public DemandController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9000/DemandSvc/");
        }
        public async Task<ActionResult> Index()
        {
            string userName = User.Identity.Name;
            string roleName = User.Claims.ToArray()[4].Value;
            string token = await client.GetStringAsync("http://localhost:9000/AuthSvc/?userName=" + userName + "&role=" + roleName + "&key=My name is James Bond");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            List<Demand> demands = await client.GetFromJsonAsync<List<Demand>>("");
            return View(demands);
        }
        /*[Route("Demand/{dmndId}")]*/
        public async Task<ActionResult> Details(string dmndId)
        {
            string userName = User.Identity.Name;
            string roleName = User.Claims.ToArray()[4].Value;
            string token = await client.GetStringAsync("http://localhost:9000/AuthSvc/?userName=" + userName + "&role=" + roleName + "&key=My name is James Bond");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            Demand demand = await client.GetFromJsonAsync<Demand>(dmndId); /*"GetByDemand/" +*/
            return View(demand);
        }
        public async Task<ActionResult> DetailsByMedicine(string medId)
        {
            string userName = User.Identity.Name;
            string roleName = User.Claims.ToArray()[4].Value;
            string token = await client.GetStringAsync("http://localhost:9000/AuthSvc/?userName=" + userName + "&role=" + roleName + "&key=My name is James Bond");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            List<Demand> demands = await client.GetFromJsonAsync<List<Demand>>("GetByMediID/" + medId);
            return View(demands);
        }

        //[Route("Demand/Insert/{demdId}")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Demand demand)
        {
            string userName = User.Identity.Name;
            string roleName = User.Claims.ToArray()[4].Value;
            string token = await client.GetStringAsync("http://localhost:9000/AuthSvc/?userName=" + userName + "&role=" + roleName + "&key=My name is James Bond");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            try
            {
                await client.PostAsJsonAsync<Demand>("", demand);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [Route("Demand/Update/{dmndId}")]
        public async Task<ActionResult> Edit(string dmndId)
        {
            string userName = User.Identity.Name;
            string roleName = User.Claims.ToArray()[4].Value;
            string token = await client.GetStringAsync("http://localhost:9000/AuthSvc/?userName=" + userName + "&role=" + roleName + "&key=My name is James Bond");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            Demand demand = await client.GetFromJsonAsync<Demand>(dmndId);
            return View(demand);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Demand/Update/{dmndId}")]
        public async Task<ActionResult> Edit(string dmndId, Demand demand)
        {
            string userName = User.Identity.Name;
            string roleName = User.Claims.ToArray()[4].Value;
            string token = await client.GetStringAsync("http://localhost:9000/AuthSvc/?userName=" + userName + "&role=" + roleName + "&key=My name is James Bond");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            try
            {
                await client.PutAsJsonAsync<Demand>(dmndId, demand);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [Route("Demand/Delete/{dmndId}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Delete(string dmndId)
        {
            string userName = User.Identity.Name;
            string roleName = User.Claims.ToArray()[4].Value;
            string token = await client.GetStringAsync("http://localhost:9000/AuthSvc/?userName=" + userName + "&role=" + roleName + "&key=My name is James Bond");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            Demand demand = await client.GetFromJsonAsync<Demand>(dmndId);
            return View(demand);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Demand/Delete/{dmndId}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Delete(string dmndId, IFormCollection collection)
        {
            string userName = User.Identity.Name;
            string roleName = User.Claims.ToArray()[4].Value;
            string token = await client.GetStringAsync("http://localhost:9000/AuthSvc/?userName=" + userName + "&role=" + roleName + "&key=My name is James Bond");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            try
            {
                await client.DeleteAsync(dmndId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}