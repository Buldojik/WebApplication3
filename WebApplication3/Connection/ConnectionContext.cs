using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using WebApplication3.Models;

namespace WebApplication3.Connection
{
    public class ConnectionContext:DbContext
    {
        public DbSet<Division> Divisions { get; set; }

        public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
