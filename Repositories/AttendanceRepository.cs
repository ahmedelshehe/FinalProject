
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Repositories
{
    public class AttendanceRepository : Repository<Attendance>
    {
        ApplicationDbContext applicationDbContext;

        public AttendanceRepository(ApplicationDbContext context) : base(context)
        {
            applicationDbContext = context;
        }
    }
}
