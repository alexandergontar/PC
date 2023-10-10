using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAPIApp.Models
{
    public class UsersContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<PC> PCs { get; set; }
        public DbSet<Disk> Disks { get; set; }
        public UsersContext(DbContextOptions<UsersContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Disk>()
                .HasOne(p => p.PC)
                .WithMany(t => t.Disks)
                .OnDelete(DeleteBehavior.Cascade);
        }*/
    }
}
