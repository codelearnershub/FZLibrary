using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibaryManagementSystem2.Models
{
    public class LibaryManagementDBContext : DbContext
    {
          public LibaryManagementDBContext(DbContextOptions<LibaryManagementDBContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
     
        public DbSet<Category> Categories {get; set; }
        public DbSet<Role> Roles {get; set; }
        public DbSet<Rack> Racks {get; set; }
        public DbSet<BookItem> BookItems {get; set; }
        public DbSet<Fine> Fines {get; set; }
        public DbSet<Lending> Lendings {get; set; }

    }
}