using LibaryManagementSystem2.Models;

namespace LibaryManagementSystem2.Interfaces
{
    public interface ILendingRepository
    {
        public Lending Add(Lending lending);

        public Lending FindById(int lendingId);

        public Lending Update(Lending lending);

        public void Delete(int fineId);
    }
}