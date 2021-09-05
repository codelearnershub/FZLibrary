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
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
         public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Category> Categories {get; set; }
        public DbSet<Role> Roles {get; set; }
        public DbSet<Rack> Racks {get; set; }
        public DbSet<BookItem> BookItems {get; set; }
        public DbSet<Fine> Fines {get; set; }
        public DbSet<Lending> Lendings {get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(u => u.PasswordHash).IsRequired();

            modelBuilder.Entity<User>().Property(u => u.HashSalt).IsRequired();

            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();


            modelBuilder.Entity<User>().Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(40);
            modelBuilder.Entity<User>().Property(u => u.FirstName).IsRequired();

            modelBuilder.Entity<User>().Property(u => u.LastName).IsRequired();

            modelBuilder.Entity<User>().Property(u => u.PhoneNumber).IsRequired();

            modelBuilder.Entity<User>().Property(u => u.Address).IsRequired();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Fariid",
                    LastName = "Ayanfe",
                    Address ="ZAmfara",
                    PhoneNumber = "07058464499",
                    Email = "fariidzikrullah@gmail.com",
                    CreatedAt = DateTime.Now,
                    PasswordHash = "EGSROdXOgd5YsDofKkZatVGf2Cnc/7O/RxhqQSmOF30=",
                    HashSalt = "J5cdgq6p63lKwmVg3b7ltQ==",
                }
                );
                  modelBuilder.Entity<Role>().Property(u => u.RoleName).IsRequired();

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    RoleName = "SuperAdmin",
                    CreatedAt = DateTime.Now,
                }
                );
                  modelBuilder.Entity<Book>().Property(u => u.Item).IsRequired();


            


           

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    Id = 1,
                    UserId = 1,
                    RoleId = 1,
                    CreatedAt = DateTime.Now,
                   
                }
                );


        }
       

    }
}
