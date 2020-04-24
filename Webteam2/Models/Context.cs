using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webteam2.Configuration;
using Webteam2.Models;

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

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Issue> Issues { get; set; }
    }
}
