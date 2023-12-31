﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class AppUser :IdentityUser
    {
        [Required(ErrorMessage = "You should enter an employee")]
        [ForeignKey("Employee")]
        public int EmpId { get; set; }
        public virtual Employee? Employee { get; set; }

        [ForeignKey("Role")]
        public string? RoleAppId { get; set; }
        public virtual AppRole? Role { get; set; }
        public IEnumerable<OfficialVacation>? OfficalVacations { get; set; } 
    }
}
