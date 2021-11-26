using EFCUTY_HFT_2021221.Models;
using EFCUTY_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCUTY_HFT_2021221.Logic
{
    public class CitizenLogic : ICitizenLogic
    {
        ICitizenRepository citizenRepository;

        public CitizenLogic(ICitizenRepository citizenRepository)
        {
            this.citizenRepository = citizenRepository;
        }

        public void Create(Citizen citizen)
        {
            DateTime earliest = new(1900, 01, 01);
            if (citizen.BirthDate < earliest)
                throw new ArgumentException("BirthDate is too early! That citizen is surely dead now.");
            citizenRepository.Create(citizen);
        }

        public Citizen Read(int id)
        {
            return citizenRepository.Read(id);
        }

        public void Update(Citizen settlement)
        {
            citizenRepository.Update(settlement);
        }

        public void Delete(int id)
        {
            citizenRepository.Delete(id);
        }

        public IEnumerable<Citizen> ReadAll()
        {
            return citizenRepository.ReadAll();
        }

        //noncrud 3: who are the people who have criminal record and live in a settlement with a HDI greater than 0.9?
        public IEnumerable<Citizen> DevelopedCriminals()
        {
            return from x in citizenRepository.ReadAll()
                   where x.Settlement.HDI > 0.9 && x.HasCriminalRecord
                   select x;
        }

        //noncrud 4: who are the people who are older than 80 years and live in a country which is not an OECD member?
        public IEnumerable<Citizen> PoorOldPeople()
        {
            return from x in citizenRepository.ReadAll()
                   where (DateTime.Now - x.BirthDate).TotalDays > 29220 && !x.Citizenship.IsOECDMember
                   select x;
        }
    }
}
