using System;
using System.Collections.Generic;
using LibaryManagementSystem2.Models;

namespace LibaryManagementSystem2.Interfaces
{
    public interface IRackRepository
    {
        public Rack Add(Rack fine);

        public Rack FindById(int fineId);

        public Rack Update(Rack fine);

        public void Delete(int fineId);
         public List<Rack> GetAll();  
    }
}