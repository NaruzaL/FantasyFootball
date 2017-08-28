using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FantasyFootball.Models
{
    public class FantasyFootballContext : IdentityDbContext<ApplicationUser>
    {
        public FantasyFootballContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=FantasyFootball;integrated security=True");
        }
        public virtual DbSet<League> Leagues { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Player> Players { get; set; }

        public FantasyFootballContext() { }
    }
}