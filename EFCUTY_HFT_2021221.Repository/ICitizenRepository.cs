using EFCUTY_HFT_2021221.Models;

namespace EFCUTY_HFT_2021221.Repository
{
    public interface ICitizenRepository
    {
        void Create(Citizen citizen);
        void Delete(int id);
        Citizen Read(int id);
        void Update(Citizen citizen);
    }
}