using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiRest.Entities;

namespace WebApiRest.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)  
                                                  : base(options)
        {
           
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Product>(p => {

                p.ToTable("tb_Product");
                p.HasKey(p => p.Id);

                p.HasMany(p => p.Reviews)
                        .WithOne(p => p.Product)
                        .HasForeignKey(p => p.ProductId)
                        .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ProductReview>(pr => {

                pr.ToTable("tb_ProductReviews");
                pr.HasKey(pr => pr.Id);
                pr.Property(pr => pr.Author)
                        .HasMaxLength(20)
                        .IsRequired();
            });
        }
        
    }
}