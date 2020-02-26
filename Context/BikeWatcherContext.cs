using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeWatcher.Models;

namespace BikeWatcher
{
    public class BikeWatcherContext : DbContext
    {
        public DbSet<FavorisModel> Favoris { get; set; }

        public BikeWatcherContext(DbContextOptions<BikeWatcherContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FavorisModel>().ToTable("Favoris");
        }
    }
}
