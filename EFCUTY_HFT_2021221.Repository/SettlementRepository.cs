using EFCUTY_HFT_2021221.Data;
using EFCUTY_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCUTY_HFT_2021221.Repository
{
    public class SettlementRepository : ISettlementRepository
    {
        WorldDbContext db;
        public SettlementRepository(WorldDbContext db)
        {
            this.db = db;
        }

        public void Create(Settlement settlement)
        {
            db.Settlements.Add(settlement);
            db.SaveChanges();
        }

        public Settlement Read(int id)
        {
            return db.Settlements.FirstOrDefault(t => t.SettlementID == id);
        }

        public void Update(Settlement settlement)
        {
            var oldSettlement = Read(settlement.SettlementID);
            oldSettlement.Population = settlement.Population;
            oldSettlement.HDI = settlement.HDI;
            oldSettlement.SettlementName = settlement.SettlementName;
            oldSettlement.CountryID = settlement.CountryID;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public IQueryable<Settlement> ReadAll()
        {
            return db.Settlements;
        }
    }
}
