using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webteam2.Configuration;
using Webteam2.Models.Geo;

namespace Webteam2.Models
{
    public class Context : IdentityDbContext<User>
    {
        public Context(DbContextOptions<Context> options) : base (options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(a => a.Profile)
                .WithOne(b => b.User)
                .HasForeignKey<Profile>(b => b.UserId);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<City> City { get; set; }

    }
}
