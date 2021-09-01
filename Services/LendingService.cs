using System;
using System.Collections.Generic;
using LibaryManagementSystem2.Interfaces;
using LibaryManagementSystem2.Models;

namespace LibaryManagementSystem2.Services
{
    public class LendingService : ILendingService
    {
        
         private readonly IUserService _userService;
         private readonly ILendingRepository _lendingRepository;
       

        public LendingService(ILendingRepository lendingRepository, IUserService userService)
        {
            _lendingRepository = lendingRepository;
            _userService = userService;
        }

        public Lending Add(Lending lend)
        {
            var lends = new Lending
            {
                CreatedAt = DateTime.Now,
                IssueDate = lend.IssueDate,
                ExpireDate = lend.ExpireDate,
                UserId = lend.UserId,
                User = lend.User,
                BookItem = lend.BookItem,
                BookItemId = lend.BookItemId,
                IsReturned = lend.IsReturned,
            };

            return _lendingRepository.Add(lend);
        }

        public Lending FindById(int id)
        {
            return _lendingRepository.FindById(id);
        }
         public List<Lending> GetAll()
        {
            return _lendingRepository.GetAll();
        }

        public Lending Update(int lendingId, Lending lending)
        {
            var lends = _lendingRepository.FindById(lendingId);
            if (lends == null)
            {
                return null;
            }

            lends.IsReturned = lending.IsReturned;
            lends.BookItemId = lending.BookItemId;
            lends.BookItem = lending.BookItem;
            lends.User = lending.User;
            lends.ExpireDate = lending.ExpireDate;
             lends.IssueDate = lending.IssueDate;
            lends.UserId = lending.UserId;
            lends.CreatedAt = DateTime.Now;

            return _lendingRepository.Update(lends);
        }

        public void Delete(int id)
        {
            _lendingRepository.Delete(id);
        }
    }
}