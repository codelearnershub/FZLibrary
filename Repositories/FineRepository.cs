using System.Linq;
using LibaryManagementSystem2.Interfaces;
using LibaryManagementSystem2.Models;

namespace LibaryManagementSystem2.Repositories
{
    public class FineRepository : IFineRepository
    {
          private readonly LibaryManagementDBContext _dbContext;

        public FineRepository(LibaryManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Fine Add(Fine fine)
        {
            _dbContext.Fines.Add(fine);
            _dbContext.SaveChanges();
            return fine;
        }

        public void Delete(int fineId)
        {
            var fines = FindById(fineId);

            if (fines != null)
            {
                _dbContext.Fines.Remove(fines);
                _dbContext.SaveChanges();
            }
        }

        public Fine FindById(int fineId)
        {
            return _dbContext.Fines.FirstOrDefault(u => u.Id.Equals(fineId));
        }

        public Fine Update(Fine fine)
        {
            _dbContext.Fines.Update(fine);
            _dbContext.SaveChanges();
            return fine;
        }
    }
}