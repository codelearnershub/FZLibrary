using System;
namespace LibaryManagementSystem2.Models
{
    public class Fine : BaseEntity
    {  
        
<<<<<<< HEAD
        public decimal? FineAmount {get; set;}
=======
        public double FineAmount {get; set;}
>>>>>>> 6744f7bed5e017ac46c097fb660b47edb0618dea
        public int UserId {get; set;}
        public int BookItemId {get; set;}
    }
}