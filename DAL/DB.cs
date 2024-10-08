﻿using System;
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
     
        public DB(DbContextOptions<DB> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Silder> silders { get; set; }

        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleGroup> ArticleGroups { get; set; }
        public DbSet<AboutUs> aboutUs { get; set; }
        public DbSet<SocialNetwork> socialNetworks { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductGroup> productGroups { get; set; }
        public DbSet<ProductComment> productComments { get; set; }
        public DbSet<ProductFeature> productFeatures { get; set; }
        public DbSet<ProductGallery> productGalleries { get; set; }
        public DbSet<ProductSpecification> productSpecifications { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Rules> Rules { get; set; }

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
