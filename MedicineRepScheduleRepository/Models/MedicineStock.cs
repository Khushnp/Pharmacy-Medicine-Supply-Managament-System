using System;
using System.Collections.Generic;

#nullable disable

namespace MedicineRepScheduleRepository.Models
{
    public partial class MedicineStock
    {
        public MedicineStock()
        {
            Schedules = new HashSet<Schedule>();
        }

        public string MedicineId { get; set; }
        public string MedincineName { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
