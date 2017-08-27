﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FantasyFootball.Models
{
    public class FantasyFootballContext
    {
        public FantasyFootballContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        //public virtual DbSet<Location> Locations { get; set; }
        //public virtual DbSet<Experience> Experiences { get; set; }
        //public virtual DbSet<People> People { get; set; }
        //public virtual DbSet<Suggestion> Suggestions { get; set; }
        public TravelBlogContext() { }
    }
}