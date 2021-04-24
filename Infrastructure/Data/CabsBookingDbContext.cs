using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data
{
    public class CabsBookingDbContext : DbContext
    {
        public CabsBookingDbContext(DbContextOptions<CabsBookingDbContext> options): base(options)
        { }
        
        public DbSet<Places> Places { get; set; }
        public DbSet<CabTypes> CabTypes { get; set; }
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<BookingsHistory> BookingsHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Places>(ConfigurePlaces);
            modelbuilder.Entity<CabTypes>(ConfigureCabTypes);
            modelbuilder.Entity<Bookings>(ConfigureBookings);
            modelbuilder.Entity<BookingsHistory>(ConfigureBookingsHistory);
        }


        private void ConfigurePlaces(EntityTypeBuilder<Places> builder)
        {
            builder.ToTable("Places");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(30);

        }
        private void ConfigureCabTypes(EntityTypeBuilder<CabTypes> builder)
        {
            builder.ToTable("CabTypes");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(30);
        }
        private void ConfigureBookings(EntityTypeBuilder<Bookings> builder)
        {
            builder.ToTable("Bookings");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Email).HasMaxLength(50);
            builder.Property(b => b.BookingDate).HasDefaultValueSql("getdate()");
            builder.Property(b => b.BookingTime).HasMaxLength(5);
            builder.Property(b => b.PickupAddress).HasMaxLength(200);
            builder.Property(b => b.Landmark).HasMaxLength(30);
            builder.Property(b => b.PickupDate).HasDefaultValueSql("getdate()");
            builder.Property(b => b.PickupTime).HasMaxLength(5);
            builder.Property(b => b.ContactNo).HasMaxLength(25);
            builder.Property(b => b.Status).HasMaxLength(30);

            builder.HasOne(b => b.Places).WithMany(b => b.Bookings).HasForeignKey(b => b.FromPlace);
            builder.HasOne(b => b.Places).WithMany(b => b.Bookings).HasForeignKey(b => b.ToPlace);
            builder.HasOne(b => b.CabTypes).WithMany(b => b.Bookings).HasForeignKey(b => b.CabTypeId);
        }
        private void ConfigureBookingsHistory(EntityTypeBuilder<BookingsHistory> builder)
        {
            builder.ToTable("BookingsHistory");
            builder.HasKey(bh => bh.Id);
            builder.Property(bh => bh.Email).HasMaxLength(50);
            builder.Property(bh => bh.BookingDate).HasDefaultValueSql("getdate()");
            builder.Property(bh => bh.BookingTime).HasMaxLength(5);
            builder.Property(bh => bh.PickupAddress).HasMaxLength(200);
            builder.Property(bh => bh.Landmark).HasMaxLength(30);
            builder.Property(bh => bh.PickupDate).HasDefaultValueSql("getdate()");
            builder.Property(bh => bh.PickupTime).HasMaxLength(5);
            builder.Property(bh => bh.ContactNo).HasMaxLength(25);
            builder.Property(bh => bh.Status).HasMaxLength(30);
            builder.Property(bh => bh.Charge).HasColumnType("money");
            builder.Property(bh => bh.Comp_Time).HasMaxLength(5);
            builder.Property(bh => bh.Feedback).HasMaxLength(1000);

            builder.HasOne(bh => bh.Places).WithMany(bh => bh.BookingsHistories).HasForeignKey(b => b.FromPlace);
            builder.HasOne(bh => bh.Places).WithMany(bh => bh.BookingsHistories).HasForeignKey(b => b.ToPlace);
            builder.HasOne(bh => bh.CabTypes).WithMany(bh => bh.BookingsHistories).HasForeignKey(b => b.CabTypeId);

        }
    }
}
