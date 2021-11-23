using EFCUTY_HFT_2021221.Data;
using EFCUTY_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCUTY_HFT_2021221.Repository
{
    public class CitizenRepository : ICitizenRepository
    {
        WorldDbContext db;
        public CitizenRepository(WorldDbContext db)
        {
            this.db = db;
        }

        public void Create(Citizen citizen)
        {
            db.Citizens.Add(citizen);
            db.SaveChanges();
        }

        public Citizen Read(int id)
        {
            return db.Citizens.FirstOrDefault(t => t.CitizenshipID == id);
        }

        public void Update(Citizen citizen)
        {
            var oldCitizen = Read(citizen.CitizenshipID);
            oldCitizen.SettlementID = citizen.SettlementID;
            oldCitizen.CitizenshipID = citizen.CitizenshipID;
            oldCitizen.HasCriminalRecord = citizen.HasCriminalRecord;
            oldCitizen.IncomeInUSD = citizen.IncomeInUSD;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public IQueryable<Citizen> GetAll()
        {
            return db.Citizens;
        }
    }
}