using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErDat
{
    class NorthwindContent : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Orderdetail> Orderdetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql(
                "server=localhost;database=northwind;uid=root;pwd=Villing5");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

         modelBuilder.Entity<Category>()
         .Property(x => x.Name).HasColumnName("categoryname");
            
         modelBuilder.Entity<Product>()
         .Property(x => x.Id).HasColumnName("productid");

         modelBuilder.Entity<Order>()
         .Property(x => x.Id).HasColumnName("orderid");

            modelBuilder.Entity<Orderdetail>()
            //.Property(x => x.Id).HasColumnName("dorderid")
           .HasKey(c => new { c.Id, c.ProductId }).HasName("orderdetailid");
        }
    }
}

/*
// fra turturiel 

    class MyContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>()
            .HasKey(b => b.BlogId)
            .HasName("PrimaryKey_BlogId");
            .HasName("");
    }
}

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>()
            .HasOne(p => p.Blog)
            .WithMany(b => b.Posts)
            .HasForeignKey(p => p.BlogUrl)
            .HasPrincipalKey(b => b.Url);
    }


    
// public DbSet<DbLoggerCategory>
//proteced override void OnConfiguring (DbContextOptionsBuilder OptionsBuilder)
///base. OnConfiguring 

 */
