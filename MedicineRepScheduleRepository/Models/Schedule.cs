using System;
using System.Collections.Generic;

#nullable disable

namespace MedicineRepScheduleRepository.Models
{
    public partial class Schedule
    {
        public string ScheduleId { get; set; }
        public string MedicalRepId { get; set; }
        public string DoctorId { get; set; }
        public string MedicineId { get; set; }
        public string MeetingSlot { get; set; }
        public DateTime? DateOfMeeting { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual MedicalRep MedicalRep { get; set; }
        public virtual MedicineStock Medicine { get; set; }
    }
}
