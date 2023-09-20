using Microsoft.AspNetCore.Identity;

namespace FinalProject.Models
{
    // All User Props To Be Added With Appropriate Data Notations 
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
