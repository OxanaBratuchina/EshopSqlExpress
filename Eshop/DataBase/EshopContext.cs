using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Eshop.Models;

namespace Eshop.DataBase
{

     public class EshopContext : DbContext
     {
        public EshopContext (DbContextOptions<EshopContext> options)
            : base(options)
        {
        }


        public DbSet<Eshop.Models.Order> Order { get; set; } = null!;
        public DbSet<Eshop.Models.Product> Product   { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<Product>()
                .HasData(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }.Select(i => new Product()
                                                                            {
                                                                                Id = i,
                                                                                Name = "Product" + i.ToString(),
                                                                                Price = 0.99 + Random.Shared.Next(1, 10000),
                                                                                Count = 0.5 * i + Random.Shared.Next(0, 100)
                                                                            }));
            modelBuilder
                .Entity<Order>()
                .HasMany(o => o.Products)
                .WithMany(p => p.Orders)
                .UsingEntity<OrderProduct>(
                    right => right
                        .HasOne(ao => ao.Product)
                        .WithMany(a => a.OrderProducts)
                        .HasForeignKey(ao => ao.ProductId),
                    left => left
                    .HasOne(ao => ao.Order)
                    .WithMany(a => a.OrderProducts)
                    .HasForeignKey(ao => ao.OrderId),

                    j =>
                    {
                        j.HasKey(k => new { k.ProductId, k.OrderId });
                    });



        }


    }
}
