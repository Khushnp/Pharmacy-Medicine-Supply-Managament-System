using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyMediSupplyRepository.Dtos
{
    public class MedicineSupplyDto
    {
        public string MedicineSupplyId { get; set; }
        public string PharmacyId { get; set; }
        public string PharmacyName { get; set; }
        public string DemandId { get; set; }
        public int? SupplyCount { get; set; }
        


    }
}
