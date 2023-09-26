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

        public  Attendance GetAttendance(Attendance attendance)
        {
            try
            {
                Attendance selectedAttendance = context.Attendances.Where(a => a.EmployeeId == attendance.EmployeeId && a.Date == attendance.Date).Include("Employee").FirstOrDefault();
                    
                return selectedAttendance;
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

        public void UpdateAttendance( Attendance attendance)
        {
            try
            {
                Attendance editAttendance = context.Attendances.Where(a => a.EmployeeId == attendance.EmployeeId && a.Date == attendance.Date).Include("Employee").FirstOrDefault();
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
                Attendance editAttendance = context.Attendances.Where(a => attendance.EmployeeId == attendance.EmployeeId && a.Date == attendance.Date).Include("Employee").FirstOrDefault();
                if (editAttendance != null)
                {
                    context.Attendances.Remove(editAttendance);
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

