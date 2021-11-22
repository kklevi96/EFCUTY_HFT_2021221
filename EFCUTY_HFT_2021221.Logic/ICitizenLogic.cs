using EFCUTY_HFT_2021221.Models;
using System.Collections.Generic;

namespace EFCUTY_HFT_2021221.Logic
{
    public interface ICitizenLogic
    {
        void Create(Citizen citizen);
        void Delete(int id);
        IEnumerable<Citizen> GetAll();
        Citizen Read(int id);
        void Update(Citizen settlement);
    }
}