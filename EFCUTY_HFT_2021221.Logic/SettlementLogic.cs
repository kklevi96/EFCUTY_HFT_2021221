using EFCUTY_HFT_2021221.Models;
using EFCUTY_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCUTY_HFT_2021221.Logic
{
    public class SettlementLogic : ISettlementLogic
    {
        ISettlementRepository settlementRepository;

        public SettlementLogic(ISettlementRepository settlementRepository)
        {
            this.settlementRepository = settlementRepository;
        }

        public void Create(Settlement settlement)
        {
            if (settlement.HDI < 0 || settlement.HDI > 1)
                throw new ArgumentException("HDI must be between 0 and 1!");
            if (settlement.Population < 1)
                throw new ArgumentException("There must be at least one person who lives in the settlement!");
            settlementRepository.Create(settlement);
        }

        public Settlement Read(int id)
        {
            return settlementRepository.Read(id);
        }

        public void Update(Settlement settlement)
        {
            if (settlement.HDI < 0 || settlement.HDI > 1)
                throw new ArgumentException("HDI must be between 0 and 1!");
            if (settlement.Population < 1)
                throw new ArgumentException("There must be at least one person who lives in the settlement!");
            settlementRepository.Update(settlement);
        }

        public void Delete(int id)
        {
            settlementRepository.Delete(id);
        }

        public IEnumerable<Settlement> GetAll()
        {
            return settlementRepository.GetAll();
        }


        //noncrud 5: list all settlements which have no people with a criminal record
        public IEnumerable<Settlement> GoodSettlements()
        {
            return from x in settlementRepository.GetAll()
                   where x.Citizens.All(y=>!y.HasCriminalRecord)
                   select x;
        }

    }
}
