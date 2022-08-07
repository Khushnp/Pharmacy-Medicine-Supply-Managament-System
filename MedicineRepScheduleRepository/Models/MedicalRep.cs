using System;
using System.Collections.Generic;

#nullable disable

namespace MedicineRepScheduleRepository.Models
{
    public partial class MedicalRep
    {
        public MedicalRep()
        {
            Schedules = new HashSet<Schedule>();
        }

        public string MedicalRepId { get; set; }
        public string MedicalRepName { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
