using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webteam2.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base (options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Issue> Issues { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Warning!
            //To protect potentially sensitive information in your connection string, you should move it out of source code.
            //See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.

            optionsBuilder.UseMySQL("server=localhost;database=library;user=user;password=password");
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
