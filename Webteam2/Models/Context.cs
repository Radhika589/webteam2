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

        internal Task<IEnumerable<Issue>> TolistAsync()
        {
            throw new NotImplementedException();
        }
    }
}
