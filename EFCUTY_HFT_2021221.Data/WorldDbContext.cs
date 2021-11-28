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
                    .HasOne(citizen => citizen.Settlement)
                    .WithMany(settlement => settlement.Citizens)
                    .HasForeignKey(citizen => citizen.SettlementID)
                    .OnDelete(DeleteBehavior.Restrict);

            });

            Country Hungary = new() //9.75M
            {
                CountryID = 1,
                Name = "Hungary",
                IsOECDMember = true,
                TotalGDPInMillionUSD = 155000
            };

            //Country Slovakia = new() //5.459M
            //{
            //    CountryID = 2,
            //    Name = "Slovakia",
            //    IsOECDMember = true,
            //    TotalGDPInMillionUSD = 104600
            //};
            //Country Cameroon = new() //26.55M
            //{
            //    CountryID = 3,
            //    Name = "Cameroon",
            //    IsOECDMember = false,
            //    TotalGDPInMillionUSD = 39800
            //};
            //Country NewZealand = new() //5.084M
            //{
            //    CountryID = 4,
            //    Name = "New Zealand",
            //    IsOECDMember = true,
            //    TotalGDPInMillionUSD = 212500
            //};
            //Country Nauru = new() //10384
            //{
            //    CountryID = 5,
            //    Name = "Nauru",
            //    IsOECDMember = false,
            //    TotalGDPInMillionUSD = 118
            //};
            //Country Spain = new() //47,35M
            //{
            //    CountryID = 6,
            //    Name = "Spain",
            //    IsOECDMember = true,
            //    TotalGDPInMillionUSD = 1281000
            //};
            //Country USA = new() //329,5M
            //{
            //    CountryID = 7,
            //    Name = "United States of America",
            //    IsOECDMember = true,
            //    TotalGDPInMillionUSD = 20940000
            //};
            //Country Bulgaria = new() //6.927M
            //{
            //    CountryID = 8,
            //    Name = "Bulgaria",
            //    IsOECDMember = false,
            //    TotalGDPInMillionUSD = 69110
            //};
            //Country Slovenia = new() //2100000
            //{
            //    CountryID = 9,
            //    Name = "Slovenia",
            //    IsOECDMember = true,
            //    TotalGDPInMillionUSD = 52880
            //};
            //Country Russia = new() //144100000
            //{
            //    CountryID = 10,
            //    Name = "Russia",
            //    IsOECDMember = false,
            //    TotalGDPInMillionUSD = 1483000
            //};
            

            Settlement Budapest = new()
            {
                SettlementID = 1,
                SettlementName = "Budapest",
                CountryID = Hungary.CountryID,
                HDI = 0.925,
                Population = 1756000
            };

            Settlement Debrecen = new()
            {
                SettlementID = 2,
                SettlementName = "Debrecen",
                CountryID = Hungary.CountryID,
                HDI = 0.893,
                Population = 202520
            };

            Settlement Miskolc = new()
            {
                SettlementID = 3,
                SettlementName = "Miskolc",
                CountryID = Hungary.CountryID,
                HDI = 0.833,
                Population = 157639
            };

            Settlement OtherHungarianSettlements = new()
            {
                SettlementID = 4,
                SettlementName = "Other Hungarian Settlements",
                CountryID = Hungary.CountryID,
                HDI = 0.899,
                Population = 7567000
            };

            //Settlement Bratislava = new()
            //{
            //    SettlementID = 5,
            //    SettlementName = "Bratislava",
            //    CountryID = Slovakia.CountryID,
            //    HDI = 0.945,
            //    Population = 424428
            //};

            //Settlement Kosice = new()
            //{
            //    SettlementID = 6,
            //    SettlementName = "Košice",
            //    CountryID = Slovakia.CountryID,
            //    HDI = 0.873,
            //    Population = 239171
            //};

            //Settlement OtherSlovakSettlements = new()
            //{
            //    SettlementID = 7,
            //    SettlementName = "Other Slovak Settlements",
            //    CountryID = Slovakia.CountryID,
            //    HDI = 0.912,
            //    Population = 4800000
            //};

            Citizen myself = new()
            {
                PersonID = 1,
                BirthDate = new DateTime(1996, 05, 22),
                CitizenshipID = Hungary.CountryID,
                SettlementID = Budapest.SettlementID,
                HasCriminalRecord = false,
                IncomeInUSD = 2000,
                Name = "Levente Kiss"
            };

            //builder.Entity<Country>().HasData(Hungary, Slovakia, Cameroon, NewZealand, Nauru);
            builder.Entity<Country>().HasData(Hungary);

            //builder.Entity<Settlement>().HasData(Budapest, Debrecen, Miskolc, OtherHungarianSettlements, Bratislava, Kosice, OtherSlovakSettlements);
            builder.Entity<Settlement>().HasData(Budapest, Debrecen, Miskolc, OtherHungarianSettlements);

            builder.Entity<Citizen>().HasData(myself);

        }
    }
}
