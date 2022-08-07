using PharmacyMediSupplyRepository.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PharmacyMediSupplyRepository.Repos
{
    public class MedicineSupplyRepo : IMedicineSupplyRepo
    {
        PharmacySupplyContext context = new PharmacySupplyContext();

        

        public async Task DeleteMedicine(string medsplyId)
        {
            MedicineSupply medsply2del = await GetMedicineById(medsplyId);
            context.MedicineSupplies.Remove(medsply2del);
            await context.SaveChangesAsync();
        }

        public async Task<List<MedicineSupply>> GetAllMedicinesSupply()
        {
            List<MedicineSupply> medicinesupplies = await context.MedicineSupplies.ToListAsync();
            return medicinesupplies;
        }

        public async Task<MedicineSupply> GetMedicineById(string medsplyId)
        {
            try
            {
               MedicineSupply medsply = await (from ms in context.MedicineSupplies where ms.MedicineSupplyId == medsplyId select ms).FirstAsync();
               return medsply;
            }
            catch (Exception)
            {
                throw new Exception("No such Medicine Supply Id found");
            }
        }

        public async Task<List<MedicineSupply>> GetMedicineByPharmacyId(string pharmaId)
        {
            List<MedicineSupply> medsply = await (from ms in context.MedicineSupplies where ms.PharmacyId == pharmaId select ms).ToListAsync();
            if (medsply.Count != 0)
                return medsply;
            else
                throw new Exception("No such Medicine supply from this Pharmacy");
        }

        public async Task InsertMedicine(MedicineSupply medsply)
        {
            Demand demand = new Demand();
            demand = await context.Demands.Where(dmnd => dmnd.DemandId == medsply.DemandId).FirstAsync();
            medsply.SupplyCount = demand.DemandCount;

            await context.MedicineSupplies.AddAsync(medsply);
            await context.SaveChangesAsync();
        }

       /* public async Task UpdateMedicine(string medsplyId, MedicineSupply medsply)
        {
            MedicineSupply medsply2edit = await GetMedicineById(medsplyId);

            medsply2edit.MedicineSupplyId = medsply.MedicineSupplyId;
            medsply2edit.PharmacyId = medsply.PharmacyId;
            medsply2edit.DemandId = medsply.DemandId;
            medsply2edit.SupplyCount = medsply.SupplyCount;

            await context.SaveChangesAsync();
        }*/
    }
}

