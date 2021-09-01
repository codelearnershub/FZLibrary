using System;
namespace LibaryManagementSystem2.Models
{
    public class Lending : BaseEntity
    {
         
        public DateTime IssueDate { get; set; }

        public DateTime ExpireDate { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int BookItemId { get; set; }

        public Book BookItem { get; set; }
        
        public bool IsReturned {get; set;}
     
    }
}