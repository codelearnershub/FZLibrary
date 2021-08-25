using System;
namespace LibaryManagementSystem2.Models
{    public class Book 
    {
        public int BookId {get; set;}
        
        public string Name {get; set;}
          
        public int RackNumber {get; set;}
        public int NumberOfItem {get; set;}

        public Rack Rack {get; set;}
        
        public int CategoryId {get; set;}

        public Category Category{ get; set;}
        public int BookItemId {get; set;}
        
        public int MaxIssueDays { get; set; }
    }
}