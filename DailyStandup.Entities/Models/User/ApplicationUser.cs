using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DailyStandup.Entities.Models.Standup;
using Microsoft.AspNetCore.Identity;

namespace DailyStandup.Entities.Models.User
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        //public Guid ProjectId { get; set; }

        //[ForeignKey("ProjectId")]
        //public IEnumerable<Project> Projects { get; set; }
    }
}
