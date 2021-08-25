using LibaryManagementSystem2.Models;

namespace LibaryManagementSystem2.Interfaces
{
    public interface IRackService
    {
        public Rack Add(Rack rack);

        public Rack FindById(int id);

        public Rack Update(int rackId, Rack rack);

        public void Delete(int id);
    }
}