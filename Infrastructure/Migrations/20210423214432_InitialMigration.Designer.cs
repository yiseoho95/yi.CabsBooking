// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(CabsBookingDbContext))]
    [Migration("20210423214432_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApplicationCore.Entities.Bookings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BookingDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("BookingTime")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int>("CabTypeId")
                        .HasColumnType("int");

                    b.Property<string>("ContactNo")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("FromPlace")
                        .HasColumnType("int");

                    b.Property<string>("Landmark")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PickupAddress")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("PickupDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("PickupTime")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Status")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("ToPlace")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CabTypeId");

                    b.HasIndex("ToPlace");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("ApplicationCore.Entities.BookingsHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BookingDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("BookingTime")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int>("CabTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Charge")
                        .HasColumnType("money");

                    b.Property<string>("Comp_Time")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNo")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Feedback")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FromPlace")
                        .HasColumnType("int");

                    b.Property<string>("Landmark")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PickupAddress")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("PickupDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("PickupTime")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Status")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("ToPlace")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CabTypeId");

                    b.HasIndex("ToPlace");

                    b.ToTable("BookingsHistory");
                });

            modelBuilder.Entity("ApplicationCore.Entities.CabTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("CabTypes");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Places", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Bookings", b =>
                {
                    b.HasOne("ApplicationCore.Entities.CabTypes", "CabTypes")
                        .WithMany("Bookings")
                        .HasForeignKey("CabTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationCore.Entities.Places", "Places")
                        .WithMany("Bookings")
                        .HasForeignKey("ToPlace")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CabTypes");

                    b.Navigation("Places");
                });

            modelBuilder.Entity("ApplicationCore.Entities.BookingsHistory", b =>
                {
                    b.HasOne("ApplicationCore.Entities.CabTypes", "CabTypes")
                        .WithMany("BookingsHistories")
                        .HasForeignKey("CabTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationCore.Entities.Places", "Places")
                        .WithMany("BookingsHistories")
                        .HasForeignKey("ToPlace")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CabTypes");

                    b.Navigation("Places");
                });

            modelBuilder.Entity("ApplicationCore.Entities.CabTypes", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("BookingsHistories");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Places", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("BookingsHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
