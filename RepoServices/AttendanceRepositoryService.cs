using FinalProject.Data;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.RepoServices
{
    public class AttendanceRepositoryService: IAttendanceRepositoryService
    {
        public ApplicationDbContext context { get; }


        public AttendanceRepositoryService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public List<Attendance> GetAttendances()
        {
            return context.Attendances.Include("Employee").ToList();
        }

        public  Attendance GetAttendance(int id,DateTime Date)
        {
            try
            {
                var attendance = context.Attendances.FirstOrDefault(a => a.Date == Date && a.EmployeeId == id);
				if(attendance !=null)
                {
                    return attendance;
                }else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());

                return null;
            }
        }

        public void InsertAttendance(Attendance attendance)
        {
            if (attendance != null)
            {
                context.Attendances.Add(attendance);
                context.SaveChanges();
            }
        }

        public void UpdateAttendance(Attendance attendance)
        {
            try
            {
                Attendance editAttendance = context.Attendances.Include("Employee")
                    .FirstOrDefault(a => a.EmployeeId == attendance.EmployeeId && a.Date == attendance.Date);
                if (editAttendance != null)
                {
                    editAttendance.ArrivalTime = attendance.ArrivalTime;
                    editAttendance.DepartureTime = attendance.DepartureTime;
                    context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
           
        }

        public void DeleteAttendance(Attendance attendance)
        {
            try
            {
				Attendance deleteAttendance = context.Attendances.Include("Employee")
					.FirstOrDefault(a => a.EmployeeId == attendance.EmployeeId && a.Date == attendance.Date); 
                if (deleteAttendance != null)
                {
                    context.Attendances.Remove(deleteAttendance);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

        }

        public bool AttendanceExists(int id, DateTime date)
        {
            return (context.Attendances?.Any(e => e.Date == date &&e.EmployeeId ==id)).GetValueOrDefault();
        }

   
    }
}

