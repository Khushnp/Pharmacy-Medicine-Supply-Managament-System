using PharmacyMediSupplyRepository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyMediSupplyRepository.Repos
{
    public interface IDemandRepo
    {
        Task<List<Demand>> GetAllDemands();
        Task<Demand> GetDemandById(string dmndId);
        Task<List<Demand>> GetDemandByMedicineId(string medId);
        Task CreateDemand(Demand demand);
        Task UpdateDemand(string dmndId, Demand demand);
        Task DeleteDemand(string dmndId);
    }
}
