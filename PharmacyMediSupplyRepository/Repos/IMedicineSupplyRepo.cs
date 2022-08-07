using PharmacyMediSupplyRepository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyMediSupplyRepository.Repos
{
    public interface IMedicineSupplyRepo
    {
        Task<List<MedicineSupply>> GetAllMedicinesSupply();
        Task<MedicineSupply> GetMedicineById(string medsplyId);
        Task<List<MedicineSupply>> GetMedicineByPharmacyId(string pharmaId);
        Task InsertMedicine(MedicineSupply medsply);
        /*Task UpdateMedicine(string medsplyId, MedicineSupply medsply);*/
        Task DeleteMedicine(string medsplyId);

    }
}
