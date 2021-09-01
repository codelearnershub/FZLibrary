using System;
using System.Collections.Generic;
using LibaryManagementSystem2.Models;

namespace LibaryManagementSystem2.Interfaces
{
    public interface IFineRepository
    {
        public Fine Add(Fine fine);

        public Fine FindById(int fineId);

        public Fine Update(Fine fine);
        public List<Fine> GetAll();  



        public void Delete(int fineId);
    }
}