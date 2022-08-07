using MedicineStockRepository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicineStockRepository.Repos
{
    public interface IMedicineStockRepo
    {
        Task<List<MedicineStock>> GetAllMedicine();
        Task<MedicineStock> GetMedicineById(string MedicineId);
        Task InsertMedicine(MedicineStock medicine);
        Task UpdateMedicine(string MedicineId, MedicineStock medicine);
        Task DeleteMedicine(string MedicineId);
    }
}
