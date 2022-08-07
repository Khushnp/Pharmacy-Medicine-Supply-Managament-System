using System;
using System.Collections.Generic;

#nullable disable

namespace PharmacyMediSupplyRepository.Models
{
    public partial class MedicineSupply
    {
        public string MedicineSupplyId { get; set; }
        public string PharmacyId { get; set; }
        public string DemandId { get; set; }
        public int? SupplyCount { get; set; }

        public virtual Demand Demand { get; set; }
        public virtual Pharmacy Pharmacy { get; set; }
    }
}
