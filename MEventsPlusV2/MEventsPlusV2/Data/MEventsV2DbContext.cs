using MEventsPlusV2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MEventsPlusV2.Data
{
    public class MEventsV2DbContext : IdentityDbContext
    {
        public MEventsV2DbContext(DbContextOptions<MEventsV2DbContext> options)
            : base(options)
            { }
        public DbSet<Events> Event { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Bookings> Booking { get; set; }
        public DbSet<CAddress> CAddresses { get; set; }
        public DbSet<CInfo> CInfos { get; set; }
        public DbSet<EAddress> EAddresses { get; set; }
        public DbSet<EInfo> EInfos { get; set; }
        public DbSet<SAddress> SAddresses { get; set; }
        public DbSet<SInfo> SInfos { get; set; }
        public DbSet<User> User1 { get; set; }
    


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Events>().ToTable("Events");
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Staff>().ToTable("Staffs");
            modelBuilder.Entity<Bookings>().ToTable("Bookings");
            modelBuilder.Entity<EAddress>().ToTable("EAddresses");
            modelBuilder.Entity<EInfo>().ToTable("EInfo");
            modelBuilder.Entity<CInfo>().ToTable("CInfo");
            modelBuilder.Entity<CAddress>().ToTable("CAddress");
            modelBuilder.Entity<SAddress>().ToTable("SAddress");
            modelBuilder.Entity<SInfo>().ToTable("SInfo");
            modelBuilder.Entity<User>().ToTable("User");

           // modelBuilder.Entity<Events>().HasOne(e => e.Bookings).WithMany().OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<Bookings>().HasMany(b => b.Customers).WithOne().OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<Bookings>().HasOne(b => b.Events).WithMany().OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<Customer>().HasOne(c => c.Bookings).WithMany().OnDelete(DeleteBehavior.Cascade);


        }
     }
    }