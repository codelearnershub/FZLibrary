using System;
namespace LibaryManagementSystem2.Models
{
    public class BookItem : BaseEntity
    {

<<<<<<< HEAD
        public string Barcode {get; set;}
        public int NumberOfItem {get; set;}
=======
        public Guid Barcode {get; set;}
>>>>>>> 6744f7bed5e017ac46c097fb660b47edb0618dea

        public int BookId {get; set;}
        
        public double FineAmount {get; set;}

       
    }
}