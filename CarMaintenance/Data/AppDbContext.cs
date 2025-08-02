﻿using CarMaintenance.Models;
using Microsoft.EntityFrameworkCore;

namespace CarMaintenance.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Cars> Tbl_Cars { get; set; }

        public DbSet<Customers> Tbl_Customers { get; set; }

        public DbSet<Receipts> Tbl_Receipts { get; set; }

        public DbSet<ReceiptsDetails> Tbl_ReceiptDetails { get; set; }

        public DbSet<Services> Tbl_Services { get; set; }

        public DbSet<TransferCars> Tbl_TransferCars { get; set; }

        public DbSet<Users> Tbl_Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Prevent cascade delete where needed

            modelBuilder.Entity<Receipts>()
                .HasOne(r => r.Customers)
                .WithMany(c => c.Receipts)
                .HasForeignKey(r => r.CustomerID)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cycle

            modelBuilder.Entity<Receipts>()
                .HasOne(r => r.Cars)
                .WithMany(c => c.Receipts)
                .HasForeignKey(r => r.CarID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TransferCars>()
                .HasOne(tc => tc.FromCustomers)
                .WithMany()
                .HasForeignKey(tc => tc.FromCustomerID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TransferCars>()
                .HasOne(tc => tc.ToCustomers)
                .WithMany()
                .HasForeignKey(tc => tc.ToCustomerID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TransferCars>()
                .HasOne(tc => tc.Cars)
                .WithMany()
                .HasForeignKey(tc => tc.CarID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReceiptsDetails>()
                .HasOne(rd => rd.Receipts)
                .WithMany(r => r.ReceiptsDetails)
                .HasForeignKey(rd => rd.ReceiptID)
                .OnDelete(DeleteBehavior.Cascade); // This can stay cascade if you want child rows auto-deleted

            modelBuilder.Entity<ReceiptsDetails>()
                .HasOne(rd => rd.Services)
                .WithMany(s => s.ReceiptsDetails)
                .HasForeignKey(rd => rd.ServiceID)
                .OnDelete(DeleteBehavior.Restrict);
        }


    }
}
