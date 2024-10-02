using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Eshop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Eshop.DataBase
{

     public class EshopContext : IdentityDbContext<AppUser>
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
            /*  modelBuilder.Entity<Client>()
                  .HasNoKey()
                  .ComplexProperty(name => name.Email, a =>
              {
                  a.Property(n => n.Value).HasColumnName("ClientEmail");
              });
              modelBuilder.Entity<Client>().ComplexProperty(name => name.Phone, a =>
              {
                  a.IsRequired();
                  a.Property(n => n.Value).HasColumnName("ClientPhone");
              });*/
            modelBuilder.Entity<Order>()
                .HasKey(i => i.Id);
            modelBuilder.Entity<Order>()
              .Property(name => name.State).HasColumnName("State")
              .IsRequired();            
            modelBuilder.Entity<Order>()
                  .Property(name => name.ClientName).HasColumnName("ClientName")
                  .IsRequired()
                  .HasMaxLength(100);            
            modelBuilder.Entity<Order>()
                  .ComplexProperty(name => name.ClientEmail, a =>
                  {
                      a.Property(n => n.Value).HasColumnName("ClientEmail");
                      a.IsRequired();
                  });

            modelBuilder.Entity<Order>()
                  .Property(name => name.DateOfCreation).HasColumnName("DateOfCreation")
                  .IsRequired();

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
            List<IdentityRole> roles = new List<IdentityRole>()
            {
                new IdentityRole(){ Name = "Admin", NormalizedName = "ADMIN"},
                new IdentityRole(){ Name = "User", NormalizedName = "USER"},
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }


    }
}
