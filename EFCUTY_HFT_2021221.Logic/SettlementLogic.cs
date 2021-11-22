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
            settlementRepository.Create(settlement);
        }

        public Settlement Read(int id)
        {
            return settlementRepository.Read(id);
        }

        public void Update(Settlement settlement)
        {
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
    }
}
