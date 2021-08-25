using System;
using LibaryManagementSystem2.Models;

namespace LibaryManagementSystem2.Interfaces
{
    public interface IFineRepository
    {
        public Fine Add(Fine fine);

        public Fine FindById(int fineId);

        public Fine Update(Fine fine);

        public void Delete(int fineId);
    }
}