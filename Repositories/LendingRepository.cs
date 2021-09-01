using System;
using System.Collections.Generic;
using System.Linq;
using LibaryManagementSystem2.Interfaces;
using LibaryManagementSystem2.Models;

namespace LibaryManagementSystem2.Repositories
{
    public class LendingRepository : ILendingRepository
    {
         private readonly LibaryManagementDBContext _dbContext;

        public LendingRepository(LibaryManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Lending Add(Lending lending)
        {
            _dbContext.Lendings.Add(lending);
            _dbContext.SaveChanges();
            return lending;
        }

        public void Delete(int lending)
        {
            var lend = FindById(lending);

            if (lend != null)
            {
                _dbContext.Lendings.Remove(lend);
                _dbContext.SaveChanges();
            }
        }

        public Lending FindById(int lendingId)
        {
            return _dbContext.Lendings.FirstOrDefault(u => u.Id.Equals(lendingId));
        }

        public Lending Update(Lending lending)
        {
            _dbContext.Lendings.Update(lending);
            _dbContext.SaveChanges();
            return lending;
        }
         public List<Lending> GetAll()
        {
            return _dbContext.Lendings.ToList();
        }
    }
}