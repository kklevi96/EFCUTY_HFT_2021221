using EFCUTY_HFT_2021221.Models;
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
            countryRepository.Create(country);
        }

        public Country Read(int id)
        {
            return countryRepository.Read(id);
        }

        public void Update(Country country)
        {
            countryRepository.Update(country);
        }

        public void Delete(int id)
        {
            countryRepository.Delete(id);
        }

        public IEnumerable<Country> GetAll()
        {
            return countryRepository.GetAll();
        }
    }
}
