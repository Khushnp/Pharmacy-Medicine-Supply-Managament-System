using System;
using System.Collections.Generic;

#nullable disable

namespace MedicineRepScheduleRepository.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Schedules = new HashSet<Schedule>();
        }

        public string DoctorId { get; set; }
        public string DoctorName { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
