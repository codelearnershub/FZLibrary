using System;
using System.Linq;
using LibaryManagementSystem2.Interfaces;
using LibaryManagementSystem2.Models;

namespace LibaryManagementSystem2.Repositories
{
    public class RackRepository : IRackRepository
    {
         private readonly LibaryManagementDBContext _dbContext;

        public RackRepository(LibaryManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Rack Add(Rack rack)
        {
            _dbContext.Racks .Add(rack);
            _dbContext.SaveChanges();
            return rack;
        }

        public void Delete(int rackId)
        {
            var racks = FindById(rackId);

            if (racks != null)
            {
                _dbContext.Racks.Remove(racks);
                _dbContext.SaveChanges();
            }
        }

        public Rack FindById(int rackId)
        {
            return _dbContext.Racks.FirstOrDefault(u => u.Id.Equals(rackId));
        }

        public Rack Update(Rack rack)
        {
            _dbContext.Racks.Update(rack);
            _dbContext.SaveChanges();
            return rack;
        }
    }
}