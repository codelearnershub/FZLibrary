using System;
namespace LibaryManagementSystem2.Models.ViewModels
{
    public class LendingViewModel
    {
        
    }
     public class AddLendingViewModel
    {
        public int Id { get; set; }

       
        public int BookItemId {get; set;}
       
         public DateTime IssueDate { get; set; }

        public DateTime ExpireDate { get; set; }

        public int UserId { get; set; }

        public bool IsReturned {get; set;}
        

    }

    public class UpdateLendingViewModel : AddLendingViewModel
    {
       
    }

    public class ListLendingViewModel
    {
        public int Id { get; set; }

        
        public int UserId { get; set; }

        public int BookItemId { get; set; }

        public bool IsReturned {get; set;}

        public DateTime IssueDate { get; set; }

        public DateTime ExpireDate { get; set; }
    }
}