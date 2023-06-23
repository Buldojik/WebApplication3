using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using WebApplication3.Models;

namespace WebApplication3.Connection
{
    public class ConnectionContext:DbContext
    {
        public DbSet<Division> Division { get; set; }
        public DbSet<Worker> Worker { get; set; }

        public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Division>()
        //        .HasOne(e => e.Worker)
        //        .WithOne(e => e.Division)
        //        .HasForeignKey<Division>(e => e.WorkerID)
        //        .IsRequired();
        //}
    }
}
