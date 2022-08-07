using MedicineStockRepository.Models;
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
    public class MedicineStockController : Controller
    {
        HttpClient client;
        public MedicineStockController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9000/MedicineStockSvc/");
        }

        public async Task<IActionResult> Index()
        {
            string userName = User.Identity.Name;
            string roleName = User.Claims.ToArray()[4].Value;
            string token = await client.GetStringAsync("http://localhost:9000/AuthSvc/?userName=" + userName + "&role=" + roleName + "&key=My name is James Bond");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            List<MedicineStock> medicineStocks = await client.GetFromJsonAsync<List<MedicineStock>>("");
            return View(medicineStocks);
        }

        [Route("MedicineStock/GetOne/{MedicineId}")]
        public async Task<ActionResult> Details(string MedicineId)
        {
            string userName = User.Identity.Name;
            string roleName = User.Claims.ToArray()[4].Value;
            string token = await client.GetStringAsync("http://localhost:9000/AuthSvc/?userName=" + userName + "&role=" + roleName + "&key=My name is James Bond");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            MedicineStock medicineStock = await client.GetFromJsonAsync<MedicineStock>(MedicineId);
            return View(medicineStock);
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Create(MedicineStock medicinestock)
        {
            string userName = User.Identity.Name;
            string roleName = User.Claims.ToArray()[4].Value;
            string token = await client.GetStringAsync("http://localhost:9000/AuthSvc/?userName=" + userName + "&role=" + roleName + "&key=My name is James Bond");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            try
            {
                await client.PostAsJsonAsync<MedicineStock>("", medicinestock);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: MedicineStockController/Edit/5
        
        [Route("MedicineStock/Update/{MedicineId}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Edit(string MedicineId)
        {
            string userName = User.Identity.Name;
            string roleName = User.Claims.ToArray()[4].Value;
            string token = await client.GetStringAsync("http://localhost:9000/AuthSvc/?userName=" + userName + "&role=" + roleName + "&key=My name is James Bond");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            MedicineStock medicineStock = await client.GetFromJsonAsync<MedicineStock>(MedicineId);
            return View(medicineStock);
        }
        // POST: MedicineStockController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("MedicineStock/Update/{MedicineId}")]
        public async Task<ActionResult> Edit(string MedicineId, MedicineStock medicinestock)
        {
            string userName = User.Identity.Name;
            string roleName = User.Claims.ToArray()[4].Value;
            string token = await client.GetStringAsync("http://localhost:9000/AuthSvc/?userName=" + userName + "&role=" + roleName + "&key=My name is James Bond");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            {
                await client.PutAsJsonAsync<MedicineStock>("" + MedicineId, medicinestock);
                return RedirectToAction(nameof(Index));
            }
        }
        [Route("MedicineStock/Delete/{MedicineId}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Delete(string MedicineId)
        {
            string userName = User.Identity.Name;
            string roleName = User.Claims.ToArray()[4].Value;
            string token = await client.GetStringAsync("http://localhost:9000/AuthSvc/?userName=" + userName + "&role=" + roleName + "&key=My name is James Bond");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            MedicineStock medicineStock = await client.GetFromJsonAsync<MedicineStock>(MedicineId);
            return View(medicineStock);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("MedicineStock/Delete/{MedicineId}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Delete(string MedicineId, IFormCollection collection)
        {
            string userName = User.Identity.Name;
            string roleName = User.Claims.ToArray()[4].Value;
            string token = await client.GetStringAsync("http://localhost:9000/AuthSvc/?userName=" + userName + "&role=" + roleName + "&key=My name is James Bond");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            try
            {
                await client.DeleteAsync(MedicineId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}