using System;
namespace LibaryManagementSystem2.Models
{
    public class BookItem : BaseEntity
    {

        public string Barcode {get; set;}
        public int NumberOfItem {get; set;}

        public int BookId {get; set;}
        
        public double FineAmount {get; set;}

       
    }
}