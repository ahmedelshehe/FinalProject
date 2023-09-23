
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Repositories
{
    public class PhoneNumberRepository : Repository<PhoneNumber>
    {
        ApplicationDbContext applicationDbContext;

        public PhoneNumberRepository(ApplicationDbContext context) : base(context)
        {
            applicationDbContext = context;
        }
    }
}
