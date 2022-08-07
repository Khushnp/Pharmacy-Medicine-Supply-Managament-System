using MedicineRepScheduleRepository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicineRepScheduleRepository.Repos
{
    public class MedicalRepScheduleRepo : IMedicalRepScheduleRepo
    {
        MedicineReprScheduleContext context = new MedicineReprScheduleContext();

        

        public async Task CreateSchedule(Schedule schedule)
        {
            await context.Schedules.AddAsync(schedule);
            await context.SaveChangesAsync();
        }

        public async Task DeleteSchedule(string schdId)
        {
            Schedule schd12del = await GetScheduleById(schdId);
            context.Schedules.Remove(schd12del);
            await context.SaveChangesAsync();
        }

        
        public async Task<List<Schedule>> GetAllSchedules()
        {
            List<Schedule> schedules = await context.Schedules.ToListAsync();
            return schedules;
        }

        public async Task<Schedule> GetScheduleById(string schdlId)
        {
            try
            {
                Schedule schdl = await (from s in context.Schedules where s.ScheduleId == schdlId select s).FirstAsync();
                return schdl;
            }
            catch (Exception)
            {
                throw new Exception("No such Schedule Id found");
            }

        }

        public async Task<List<Schedule>> GetSchedulesByDoctorId(string docId)
        {
            List<Schedule> schedules = await (from s in context.Schedules where s.DoctorId == docId select s).ToListAsync();
            if (schedules.Count != 0)
                return schedules;
            else
                throw new Exception("No Schedules found for the Doctor");
        }

        public async Task<List<Schedule>> GetSchedulesByMedicalRepId(string medrepId)
        {
            List<Schedule> schedules = await(from s in context.Schedules where s.MedicalRepId == medrepId select s).ToListAsync();
            if (schedules.Count != 0)
                return schedules;
            else
                throw new Exception("No Schedules found for the Medical Representative");
        }

        public async Task<List<Schedule>> GetSchedulesByMedicineId(string medId)
        {
            List<Schedule> schedules = await (from s in context.Schedules where s.MedicineId == medId select s).ToListAsync();
            if (schedules.Count != 0)
                return schedules;
            else
                throw new Exception("No Schedules found based on this Medicine");
        }

        public async Task UpdateSchedule(string schdId, Schedule schedule)
        {
            Schedule schdl2edit = await GetScheduleById(schdId);

            schdl2edit.MedicineId = schedule.MedicineId;
            schdl2edit.MedicalRepId = schedule.MedicalRepId;
            schdl2edit.DoctorId = schedule.DoctorId;
            schdl2edit.DateOfMeeting = schedule.DateOfMeeting;
            schdl2edit.MeetingSlot = schedule.MeetingSlot;

            await context.SaveChangesAsync();
        }
    }
}




/*//trying to get all the doctor list 
public async Task<List<Doctor>> GetAllDoctors()
{
    List<Doctor> doctors = await context.Doctors.ToListAsync();
    return doctors;
}
public async Task CreateDoctor(Doctor doctor)
{
    await context.Doctors.AddAsync(doctor);
    await context.SaveChangesAsync();
}
*/