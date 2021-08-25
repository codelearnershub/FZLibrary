using System;
namespace LibaryManagementSystem2.Models
{
    public class Fine : BaseEntity
    {  
        
        public decimal? FineAmount {get; set;}
        public int UserId {get; set;}
        public int BookItemId {get; set;}
    }
}