using EFCUTY_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EFCUTY_HFT_2021221.Data
{
    public class WorldDbContext : DbContext
    {
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Settlement> Settlements { get; set; }

        public WorldDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string conn =
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\World.mdf;Integrated Security=True";
                builder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Settlement>(entity =>
            {
                entity
                    .HasOne(settlement => settlement.Country)
                    .WithMany(country => country.Settlements)
                    .HasForeignKey(settlement => settlement.CountryID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Citizen>(entity =>
            {
                entity
                    .HasOne(citizen => citizen.Citizenship)
                    .WithMany(country => country.Citizens)
                    .HasForeignKey(citizen => citizen.CitizenshipID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(citizen => citizen.HomeSettlement)
                    .WithMany(settlement => settlement.Citizens)
                    .HasForeignKey(citizen => citizen.SettlementID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        }
    }
}
