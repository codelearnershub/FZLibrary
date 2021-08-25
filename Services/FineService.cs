using System;
using LibaryManagementSystem2.Interfaces;
using LibaryManagementSystem2.Models;

namespace LibaryManagementSystem2.Services
{
    public class FineService : IFineService
    {
         private readonly IUserService _userService;
         private readonly IFineRepository _fineRepository;
       

        public FineService(IFineRepository fineRepository, IUserService userService)
        {
            _fineRepository = fineRepository;
            _userService = userService;
        }

        public Fine Add(Fine fine)
        {
            var fines = new Fine
            {
                CreatedAt = DateTime.Now,
                FineAmount = fine.FineAmount,
                UserId = fine.UserId,
                BookItemId = fine.BookItemId,
            };

            return _fineRepository.Add(fine);
        }

        public Fine FindById(int id)
        {
            return _fineRepository.FindById(id);
        }

        public Fine Update(int fineId, Fine fine)
        {
            var fines = _fineRepository.FindById(fineId);
            if (fines == null)
            {
                return null;
            }

            fines.FineAmount = fine.FineAmount;
            fines.BookItemId = fine.BookItemId;
            fines.UserId = fine.UserId;
            fines.CreatedAt = DateTime.Now;

            return _fineRepository.Update(fines);
        }

        public void Delete(int id)
        {
            _fineRepository.Delete(id);
        }
    }
}