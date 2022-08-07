using MedicineRepScheduleRepository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicineRepScheduleRepository.Repos
{
    public interface IMedicalRepScheduleRepo
    {
        Task<List<Schedule>> GetAllSchedules();
        Task<Schedule> GetScheduleById(string schdlId);
        Task<List<Schedule>> GetSchedulesByMedicalRepId(string medrepId);
        Task<List<Schedule>> GetSchedulesByDoctorId(string docId);
        Task<List<Schedule>> GetSchedulesByMedicineId(string medId);
        Task CreateSchedule(Schedule schedule);
        Task UpdateSchedule(string schdId ,Schedule schedule);
        Task DeleteSchedule(string schdId);

        /*//trying to get all the doctor list 
        Task<List<Doctor>> GetAllDoctors();
        Task CreateDoctor(Doctor doctor);*/
    }
}
