using System;
using System.Collections.Generic;

#nullable disable

namespace PharmacyMediSupplyRepository.Models
{
    public partial class MedicineStock
    {
        public MedicineStock()
        {
            Demands = new HashSet<Demand>();
        }

        public string MedicineId { get; set; }
        public string MedicineName { get; set; }
        public int? NumberOfTabletsInStock { get; set; }

        public virtual ICollection<Demand> Demands { get; set; }
    }
}
