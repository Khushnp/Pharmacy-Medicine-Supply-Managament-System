using Microsoft.EntityFrameworkCore;
using PharmacyMediSupplyRepository.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyMediSupplyRepository.Repos
{
    public class DemandRepo : IDemandRepo
    {
        PharmacySupplyContext context = new PharmacySupplyContext();
        public async Task CreateDemand(Demand demand)
        {

            MedicineStock medicinestock = new MedicineStock();
            medicinestock = await context.MedicineStocks.Where(medstok => medstok.MedicineId == demand.MedicineId).FirstAsync();
            if (demand.DemandCount > medicinestock.NumberOfTabletsInStock)
            {
                demand.DemandCount = medicinestock.NumberOfTabletsInStock;
            }

            await context.Demands.AddAsync(demand);
                await context.SaveChangesAsync();

        }

        public async Task DeleteDemand(string dmndId)
        {
            Demand dmnd2del = await GetDemandById(dmndId);
            context.Demands.Remove(dmnd2del);
            await context.SaveChangesAsync();
        }

        public async Task<List<Demand>> GetAllDemands()
        {
            List<Demand> demands = await context.Demands.ToListAsync();
            return demands;
        }

        public async Task<Demand> GetDemandById(string dmndId)
        {
            try
            {
                Demand dmnd = await (from d in context.Demands where d.DemandId == dmndId select d).FirstAsync();
                return dmnd;
            }
            catch (Exception)
            {
                throw new Exception("No such Demand Id found");
            }
        }

        public async Task<List<Demand>> GetDemandByMedicineId(string medId)
        {
            List<Demand> demands = await (from d in context.Demands where d.MedicineId == medId select d).ToListAsync();
            if (demands.Count != 0)
            {
                return demands;
            }

            else
            {
                throw new Exception("No such demands for this Medicine");
            }

        }

        public async Task UpdateDemand(string dmndId, Demand demand)
        {
            Demand dmnd = await GetDemandById(dmndId);


            MedicineStock medicine = new MedicineStock();

            if ((demand.MedicineId == medicine.MedicineId) && (demand.DemandCount > medicine.NumberOfTabletsInStock))
            {
                dmnd.DemandCount = medicine.NumberOfTabletsInStock;
            }
            else
            {
                dmnd.DemandCount = demand.DemandCount;
            }
            dmnd.MedicineId = demand.MedicineId;

            await context.SaveChangesAsync();
        }
    }
}
