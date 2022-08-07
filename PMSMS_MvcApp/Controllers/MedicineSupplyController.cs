using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyMediSupplyRepository.Dtos;
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
    public class MedicineSupplyController : Controller
    {
        HttpClient client;
        public MedicineSupplyController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9000/MedicineSupplySvc/");
        }

        /*[Route("MedicineSupply/GetAll")]*/
        public async Task<ActionResult> Index()
        {
            string userName = User.Identity.Name;
            string roleName = User.Claims.ToArray()[4].Value;
            string token = await client.GetStringAsync("http://localhost:9000/AuthSvc/?userName=" + userName + "&role=" + roleName + "&key=My name is James Bond");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            List<MedicineSupply> medicineSupplies = await client.GetFromJsonAsync<List<MedicineSupply>>("");
            return View(medicineSupplies);
        }
        public async Task<ActionResult> Details(string medsplyId)
        {
            string userName = User.Identity.Name;
            string roleName = User.Claims.ToArray()[4].Value;
            string token = await client.GetStringAsync("http://localhost:9000/AuthSvc/?userName=" + userName + "&role=" + roleName + "&key=My name is James Bond");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            MedicineSupplyDto medicineSupplyDto = await client.GetFromJsonAsync<MedicineSupplyDto>( medsplyId);
            return View(medicineSupplyDto);
        }
        public async Task<ActionResult> DetailsByPharmacy(string phrId)
        {
            string userName = User.Identity.Name;
            string roleName = User.Claims.ToArray()[4].Value;
            string token = await client.GetStringAsync("http://localhost:9000/AuthSvc/?userName=" + userName + "&role=" + roleName + "&key=My name is James Bond");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            List<MedicineSupply> medicineSupplies = await client.GetFromJsonAsync<List<MedicineSupply>>("GetByPharmacy/" + phrId);
            return View(medicineSupplies);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MedicineSupply medicinesupply)
        {
            string userName = User.Identity.Name;
            string roleName = User.Claims.ToArray()[4].Value;
            string token = await client.GetStringAsync("http://localhost:9000/AuthSvc/?userName=" + userName + "&role=" + roleName + "&key=My name is James Bond");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            try
            {
                await client.PostAsJsonAsync<MedicineSupply>("", medicinesupply);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        /*[Route("MedicineSupply/UpdateMedicine/{medsplyId}")]
        public async Task<ActionResult> Edit(string medsplyId)
        {
            string userName = User.Identity.Name;
            string roleName = User.Claims.ToArray()[4].Value;
            string token = await client.GetStringAsync("http://localhost:9000/AuthSvc/?userName=" + userName + "&role=" + roleName + "&key=My name is James Bond");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            MedicineSupply medicinesupply = await client.GetFromJsonAsync<MedicineSupply>( medsplyId);
            return View(medicinesupply);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("MedicineSupply/UpdateMedicine/{medsplyId}")]
        public async Task<ActionResult> Edit(string medsplyId, MedicineSupply medicineSupply)
        {
            string userName = User.Identity.Name;
            string roleName = User.Claims.ToArray()[4].Value;
            string token = await client.GetStringAsync("http://localhost:9000/AuthSvc/?userName=" + userName + "&role=" + roleName + "&key=My name is James Bond");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            try
            {
                await client.PutAsJsonAsync<MedicineSupply>(medsplyId, medicineSupply);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/

        [Route("MedicineSupply/DeleteMedicine/{medsplyId}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Delete(string medsplyId)
        {
            string userName = User.Identity.Name;
            string roleName = User.Claims.ToArray()[4].Value;
            string token = await client.GetStringAsync("http://localhost:9000/AuthSvc/?userName=" + userName + "&role=" + roleName + "&key=My name is James Bond");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            MedicineSupply medicinesupply = await client.GetFromJsonAsync<MedicineSupply>(medsplyId);
            return View(medicinesupply);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("MedicineSupply/DeleteMedicine/{medsplyId}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Delete(string medsplyId, IFormCollection collection)
        {
            string userName = User.Identity.Name;
            string roleName = User.Claims.ToArray()[4].Value;
            string token = await client.GetStringAsync("http://localhost:9000/AuthSvc/?userName=" + userName + "&role=" + roleName + "&key=My name is James Bond");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            try
            {
                await client.DeleteAsync(medsplyId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}