using HotDrinks.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace HotDrinks.Data
{
    public class DataContext : DbContext
    {
        public DbSet<HotDrinkAction> HotDrinkActions { get; set; }
        public DbSet<HotDrink> HotDrinks { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HotDrinkAction>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Description).IsRequired();
                entity.Property(e => e.Name).IsRequired();
				entity.HasIndex(e => e.Name).IsUnique();
			});

            modelBuilder.Entity<HotDrink>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.HasIndex(e => e.Name).IsUnique();
            });

            modelBuilder.Entity<HotDrink>()
                .HasMany(e => e.Actions)
                .WithMany(e => e.Drinks);


        }
    }
}
