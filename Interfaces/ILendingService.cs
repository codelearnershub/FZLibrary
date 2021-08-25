using LibaryManagementSystem2.Models;

namespace LibaryManagementSystem2.Interfaces
{
    public interface ILendingService
    {
        public Lending Add(Lending lending);

        public Lending FindById(int id);

        public Lending Update(int LendingId, Lending lending);

        public void Delete(int id);
    }
}