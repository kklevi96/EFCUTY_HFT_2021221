using EFCUTY_HFT_2021221.Models;

namespace EFCUTY_HFT_2021221.Repository
{
    public interface ISettlementRepository
    {
        void Create(Settlement settlement);
        void Delete(int id);
        Settlement Read(int id);
        void Update(Settlement settlement);
    }
}