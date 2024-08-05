using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DAL
{
    public class DB : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=MoblieShop;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
        }
        //public DB(DbContextOptions<DB> options) : base(options)
        //{

        //}
        public DbSet<BE.User> Users { get; set; }
        public DbSet<BE.Role> roles { get; set; }

        public DbSet<BE.Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Role>().HasData(new Role()
            {
                RoleTitle = "Admin",
                RoleId = 1
            }, new Role()
            {
                RoleTitle = "User",
                RoleId = 2
            });

        }
    }
}
