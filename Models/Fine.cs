using System;
namespace LibaryManagementSystem2.Models
{
    public class Fine
    {
        public int UserId {get; set;}
        public double Amount {get; set;}
        public int BookItemId {get; set;}
    }
}