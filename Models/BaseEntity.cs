using System;

namespace LibaryManagementSystem2.Models
{
    public class BaseEntity
    {
        public int Id {get; set;}
         public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}