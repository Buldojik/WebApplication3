﻿using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.DataBase.Connection
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Division> Division { get; set; }
        public DbSet<Worker> Worker { get; set; }
        public DbSet<LaborCosts> LaborCosts { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Quest> Quest { get; set; }

        public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
