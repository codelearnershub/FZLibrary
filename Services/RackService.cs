using System;
using System.Collections.Generic;
using LibaryManagementSystem2.Interfaces;
using LibaryManagementSystem2.Models;

namespace LibaryManagementSystem2.Services
{
    public class RackService : IRackService
    {
         private readonly IUserService _userService;
         private readonly IRackRepository _rackRepository;
       

        public RackService(IRackRepository rackRepository, IUserService userService)
        {
            _rackRepository = rackRepository;
            _userService = userService;
        }

        public Rack Add(Rack rack)
        {
            var racks = new Rack
            {
               
                RackNumber = rack.RackNumber,
                Location = rack.Location,
               
            };

            return _rackRepository.Add(rack);
        }

        public Rack FindById(int id)
        {
            return _rackRepository.FindById(id);
        }

        public Rack Update(Rack rack)
        {
            var racks = _rackRepository.FindById(rack.Id);
            if (racks == null)
            {
                return null;
            }
            

            racks.RackNumber = rack.RackNumber;
            racks.Location = rack.Location;

           

            return _rackRepository.Update(racks);
        }

        public void Delete(int id)
        {
            _rackRepository.Delete(id);
        }

        public List<Rack> GetAll()
        {
            return _rackRepository.GetAll();
        }
    }
}