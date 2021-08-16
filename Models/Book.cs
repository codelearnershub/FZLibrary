using System;
namespace LibaryManagementSystem2.Models
{    public class Book 
    {
        public int BookId {get; set;}

        public string Name {get; set;}

        public int RackNumber {get; set;}

        public Rack Rack {get; set;}
        
        public int MaxIssueDays { get; set; }
    }
}