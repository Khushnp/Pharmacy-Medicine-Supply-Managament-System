using MedicineStockRepository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineStockRepository.Repos
{
    public class MedicineStockRepo : IMedicineStockRepo
    {
        MedicineInventoryContext context = new MedicineInventoryContext();
        public async Task DeleteMedicine(string medId)
        {
            MedicineStock med2del = await GetMedicineById(medId);
            context.MedicineStocks.Remove(med2del);
            await context.SaveChangesAsync();
            
        }


        public async Task<List<MedicineStock>> GetAllMedicine()
        {
            List<MedicineStock> medicineStocks = await context.MedicineStocks.ToListAsync();
            return medicineStocks;
        }

        public async Task<MedicineStock> GetMedicineById(string medId)
        {
            try
            {
                MedicineStock medicine = await (from m in context.MedicineStocks where m.MedicineId == medId select m).FirstAsync();
                return medicine;
            }
            catch (Exception)
            {
                throw new Exception("No such Medicine Found");
            }
        }

        public async Task InsertMedicine(MedicineStock medicine)
        {
            await context.MedicineStocks.AddAsync(medicine);
            await context.SaveChangesAsync();
        }

        public async Task UpdateMedicine(string medId, MedicineStock medicine)
        {
            MedicineStock med2edit = await GetMedicineById(medId);

            med2edit.MedicineName = medicine.MedicineName;
            med2edit.ChemicalComposition = medicine.ChemicalComposition;
            med2edit.TargetAilment = medicine.TargetAilment;
            med2edit.DateOfExpiry = medicine.DateOfExpiry;
            med2edit.NumberOfTabletsInStock = medicine.NumberOfTabletsInStock;

            await context.SaveChangesAsync();

        }
    }
}
