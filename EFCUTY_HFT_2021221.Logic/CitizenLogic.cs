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

        public IEnumerable<Citizen> GetAll()
        {
            return citizenRepository.GetAll();
        }
    }
}
