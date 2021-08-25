using LibaryManagementSystem2.Models;

namespace LibaryManagementSystem2.Interfaces
{
    public interface IFineService
    {
         public Fine Add(Fine fine);

        public Fine FindById(int id);

        public Fine Update(int salesId, Fine fine);

        public void Delete(int id);
    }
}
