using System;
using System.Collections.Generic;

#nullable disable

namespace PharmacyMediSupplyRepository.Models
{
    public partial class Pharmacy
    {
        public Pharmacy()
        {
            MedicineSupplies = new HashSet<MedicineSupply>();
        }

        public string PharmacyId { get; set; }
        public string PharmacyName { get; set; }

        public virtual ICollection<MedicineSupply> MedicineSupplies { get; set; }
    }
}
