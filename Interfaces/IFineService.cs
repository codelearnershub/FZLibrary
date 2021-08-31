using System.Collections.Generic;
using LibaryManagementSystem2.Models;

namespace LibaryManagementSystem2.Interfaces
{
    public interface IFineService
    {
         public Fine Add(Fine fine);

        public Fine FindById(int id);

        public Fine Update(Fine fine);

        public void Delete(int id);
        public List<Fine> GetAll();


    }
}
