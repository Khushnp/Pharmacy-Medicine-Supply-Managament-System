using PharmacyMediSupplyRepository.Dtos;
using PharmacyMediSupplyRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyMediSupplyService
{
     public static class Extension
    {
        
        public static MedicineSupplyDto AsDto(this MedicineSupply medicineSupply)
        {
            PharmacySupplyContext context = new PharmacySupplyContext();
            var pharmacy = context.Pharmacies.Where(p=> p.PharmacyId == medicineSupply.PharmacyId).First();
            return new MedicineSupplyDto()
            {
                MedicineSupplyId = medicineSupply.MedicineSupplyId,
                PharmacyId = medicineSupply.PharmacyId,
                PharmacyName =pharmacy.PharmacyName,
                DemandId = medicineSupply.DemandId,
                SupplyCount = medicineSupply.SupplyCount
            };
        }
    }
}
