﻿using EFCUTY_HFT_2021221.Models;
using EFCUTY_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCUTY_HFT_2021221.Logic
{
    public class CountryLogic : ICountryLogic
    {
        ICountryRepository countryRepository;

        public CountryLogic(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }



        public void Create(Country country)
        {
            if (country.TotalGDPInMillionUSD < 100)
                throw new ArgumentException("A country just can't be that poor!");
            if (ThisNameExists(country.Name))
                throw new ArgumentException("The country with this name already exists!");
            countryRepository.Create(country);
        }

        public Country Read(int id)
        {
            return countryRepository.Read(id);
        }

        public void Update(Country country)
        {
            if (country.TotalGDPInMillionUSD < 100)
                throw new ArgumentException("A country just can't be that poor!");
            if (ThisNameExists(country.Name))
                throw new ArgumentException("The country with this name already exists!");
            countryRepository.Update(country);
        }

        public void Delete(int id)
        {
            countryRepository.Delete(id);
        }

        public IEnumerable<Country> ReadAll()
        {
            return countryRepository.ReadAll();
        }

        //noncrud 1: which countries have a GDP per capita less than 10000 USD?

        public IEnumerable<Country> PoorCountries()
        {
            return from x in countryRepository.ReadAll()
                   where x.TotalGDPInMillionUSD / CountPopulation(x) < 10
                   select x;
        }

        //helper method for noncrud 1
        public static int CountPopulation(Country country)
        {
            return country
                .Settlements
                .Select(x => x.Population)
                .Sum();
        }

        //noncrud 2: list the population of the OECD member countries
        public IEnumerable<KeyValuePair<string, int>> PopulationOECD()
        {
            return from x in countryRepository.ReadAll()
                   where x.IsOECDMember
                   select new KeyValuePair<string, int>
                   (
                       x.Name,
                       CountPopulation(x)
                   );
        }

        //helper method for Create
        public bool ThisNameExists(string name)
        {
            //var a = from x in countryRepository.GetAll()
            //where x.Name.Equals(name)
            //select x;
            //return a.Count() > 0

            return countryRepository.ReadAll()
                .Any(x => x.Name == name);
        }


    }
}
