﻿// <auto-generated />
using Async_Inn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AsyncInn.Migrations
{
    [DbContext(typeof(HotelDbContext))]
    [Migration("20181107033731_initials")]
    partial class initials
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Async_Inn.Models.Amenity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Amenities");

                    b.HasData(
                        new { ID = 1, Name = "Beachfront" },
                        new { ID = 2, Name = "Vaulted Ceilings" },
                        new { ID = 3, Name = "Air Conditioning" },
                        new { ID = 4, Name = "Mini Keg" },
                        new { ID = 5, Name = "Hottub" }
                    );
                });

            modelBuilder.Entity("Async_Inn.Models.Hotel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.HasKey("ID");

                    b.ToTable("Hotels");

                    b.HasData(
                        new { ID = 1, Address = " 15th SW ARMORY LN.", Name = "Day Inn", Phone = "663-985-7894" },
                        new { ID = 2, Address = " 155th Holiday Dr.", Name = "Holiday Inn", Phone = "109-848-9654" },
                        new { ID = 3, Address = " 11th Shadow St.", Name = "Spooky Express", Phone = "666-989-8456" },
                        new { ID = 4, Address = "333 Money St.", Name = "Treway Inn", Phone = "330-489-8974" },
                        new { ID = 5, Address = "178th Broke St.", Name = "Shawn's Budget Inn", Phone = "478-895-6987" }
                    );
                });

            modelBuilder.Entity("Async_Inn.Models.HotelRoom", b =>
                {
                    b.Property<int>("HotelID");

                    b.Property<int>("RoomID");

                    b.Property<bool>("PetFriendly");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RoomNumber");

                    b.HasKey("HotelID", "RoomID");

                    b.HasIndex("RoomID");

                    b.ToTable("HotelRooms");
                });

            modelBuilder.Entity("Async_Inn.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Layout");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Rooms");

                    b.HasData(
                        new { ID = 1, Layout = 1, Name = "Baller Suite" },
                        new { ID = 2, Layout = 0, Name = "Honeymooner" },
                        new { ID = 3, Layout = 2, Name = "Paradise Lounge" },
                        new { ID = 4, Layout = 2, Name = "Zoo Infusion" },
                        new { ID = 5, Layout = 1, Name = "Safari Experience" }
                    );
                });

            modelBuilder.Entity("Async_Inn.Models.RoomAmenity", b =>
                {
                    b.Property<int>("RoomID");

                    b.Property<int>("AmenityID");

                    b.HasKey("RoomID", "AmenityID");

                    b.HasIndex("AmenityID");

                    b.ToTable("RoomAmenities");
                });

            modelBuilder.Entity("Async_Inn.Models.HotelRoom", b =>
                {
                    b.HasOne("Async_Inn.Models.Hotel", "Hotel")
                        .WithMany("HotelRooms")
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Async_Inn.Models.Room", "Room")
                        .WithMany("HotelRooms")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Async_Inn.Models.RoomAmenity", b =>
                {
                    b.HasOne("Async_Inn.Models.Amenity", "Amenity")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("AmenityID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Async_Inn.Models.Room", "Room")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
