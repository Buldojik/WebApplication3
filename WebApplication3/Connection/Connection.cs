using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using WebApplication3.Models;

namespace WebApplication3.Connection
{
    public class Connection:DbContext
    {
        public DbSet<Division> Divisions { get; set; }

        public Connection(DbContextOptions<Connection> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
