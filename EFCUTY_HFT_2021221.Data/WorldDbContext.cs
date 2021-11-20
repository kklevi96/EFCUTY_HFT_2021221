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
        public virtual DbSet<Citizen> Citizens { get; set; }

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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Settlement>(entity =>
            {
                entity
                    .HasOne(settlement => settlement.Country)
                    .WithMany(country => country.Settlements)
                    .HasForeignKey(settlement => settlement.CountryID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Citizen>(entity =>
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

            Country Canada = new() { CountryID = 1 };
            Country Hungary = new() { CountryID = 2 };
            Country Ukraine = new() { CountryID = 3 };
            Country Bulgaria = new() { CountryID = 4 };

            Settlement Plovdiv = new() { SettlementID = 1, CountryID = 4, Population = 180000 };
            Settlement Budapest = new() { SettlementID = 2, CountryID = 2, Population = 1800000 };
            Settlement Kiev = new() { SettlementID = 3, CountryID = 3, Population = 3500000 };
            Settlement Lvov = new() { SettlementID = 4, CountryID = 4, Population = 1850000 };

            Citizen citizen = new() { PersonID = 1, BirthDate = new DateTime(1996, 12, 11), Name = "Török Tamás", SettlementID = 2, CitizenshipID = 2 };
            Citizen citizen2 = new() { PersonID = 2, BirthDate = new DateTime(1647, 5, 13), Name = "Orbán Viktor", SettlementID = 2, CitizenshipID = 2 };
            Citizen citizen3 = new() { PersonID = 3, BirthDate = new DateTime(1920, 12, 11), Name = "Joe Trump", SettlementID = 4, CitizenshipID = 1 };

            builder.Entity<Country>().HasData(Canada, Hungary, Ukraine, Bulgaria);
            builder.Entity<Settlement>().HasData(Plovdiv, Budapest, Kiev, Lvov);
            builder.Entity<Citizen>().HasData(citizen, citizen2, citizen3);

        }
    }
}
