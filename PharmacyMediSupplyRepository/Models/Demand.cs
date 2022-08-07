using System;
using System.Collections.Generic;

#nullable disable

namespace PharmacyMediSupplyRepository.Models
{
    public partial class Demand
    {
        public Demand()
        {
            MedicineSupplies = new HashSet<MedicineSupply>();
        }

        public string DemandId { get; set; }
        public string MedicineId { get; set; }
        public int? DemandCount { get; set; }

        public virtual MedicineStock Medicine { get; set; }
        public virtual ICollection<MedicineSupply> MedicineSupplies { get; set; }
    }
}
