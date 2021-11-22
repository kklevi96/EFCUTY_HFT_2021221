using EFCUTY_HFT_2021221.Models;
using System.Collections.Generic;

namespace EFCUTY_HFT_2021221.Logic
{
    public interface ISettlementLogic
    {
        void Create(Settlement settlement);
        void Delete(int id);
        IEnumerable<Settlement> GetAll();
        Settlement Read(int id);
        void Update(Settlement settlement);
    }
}