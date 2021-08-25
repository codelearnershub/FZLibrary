using System;

namespace LibaryManagementSystem2.Models
{
    public class BaseEntity
    {
        public int Id {get; set;}
         public DateTime CreatedAt { get; set; }

<<<<<<< HEAD
=======
        public string CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }
>>>>>>> 6744f7bed5e017ac46c097fb660b47edb0618dea
    }
}