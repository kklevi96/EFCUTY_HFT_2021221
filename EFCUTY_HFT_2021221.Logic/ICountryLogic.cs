using EFCUTY_HFT_2021221.Models;
using System.Collections.Generic;

namespace EFCUTY_HFT_2021221.Logic
{
    public interface ICountryLogic
    {
        void Create(Country country);
        void Delete(int id);
        IEnumerable<Country> GetAll();
        Country Read(int id);
        void Update(Country country);
    }
}