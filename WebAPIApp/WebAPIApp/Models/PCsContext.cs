using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAPIApp.Models
{
    public class PCsContext : DbContext
    {
        public DbSet<PC> PCs { get; set; }
        public PCsContext(DbContextOptions<PCsContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
          
    }
}
