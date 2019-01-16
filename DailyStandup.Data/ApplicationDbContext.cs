using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DailyStandup.Web.Models;
using DailyStandup.Entities.Models.User;
using DailyStandup.Entities.Models.Standup;

namespace DailyStandup.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("DailyStandup");
            base.OnModelCreating(builder);

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            builder.Entity<ApplicationUser>().ToTable("ApplicationUsers");
            builder.Entity<ApplicationRole>().ToTable("ApplicationRoles");

            
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Work> Worksssss { get; set; }
        public DbSet<Obstacle> Obstacles { get; set; }
    }
}
