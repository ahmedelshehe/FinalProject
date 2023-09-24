using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class AppRole :IdentityRole
    {
        public AppRole(string name):base(name) 
        {

        }

        public virtual IEnumerable<AppUser>? Users { get; set;}

        public virtual IEnumerable<Permission>? Permissions { get; set;}
    }
}
