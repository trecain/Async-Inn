using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Async_Inn.Models;

namespace Async_Inn.Data
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<RoomAmenity>().HasKey(ce => new {ce.AmenityID, ce.RoomID });
            mb.Entity<HotelRoom>().HasKey(ce => new { ce.HotelID, ce.RoomNumber });

            mb.Entity<Hotel>().HasData(
                new Hotel
                {
                    ID = 1,
                    Name = "Day Inn",
                    Address = " 15th SW ARMORY LN.",
                    Phone = "663-985-7894"
                },
                 new Hotel
                 {
                     ID = 2,
                     Name = "Holiday Inn",
                     Address = " 155th Holiday Dr.",
                     Phone = "109-848-9654"
                 },
                  new Hotel
                  {
                      ID = 3,
                      Name = "Spooky Express",
                      Address = " 11th Shadow St.",
                      Phone = "666-989-8456"
                  },
                   new Hotel
                   {
                       ID = 4,
                       Name = "Treway Inn",
                       Address = "333 Money St.",
                       Phone = "330-489-8974"
                   },
                    new Hotel
                    {
                        ID = 5,
                        Name = "Shawn's Budget Inn",
                        Address = "178th Broke St.",
                        Phone = "478-895-6987"
                    }
                );

            mb.Entity<Room>().HasData(
                new Room
                {
                    ID = 1,
                    Name = "Baller Suite",
                    Layout = (Layout)1
                },
                new Room
                {
                    ID = 2,
                    Name = "Honeymooner",
                    Layout = 0
                },
                new Room
                {
                    ID = 3,
                    Name = "Paradise Lounge",
                    Layout = (Layout)2
                },
                new Room
                {
                    ID = 4,
                    Name = "Zoo Infusion",
                    Layout = (Layout)2
                },
                new Room
                {
                    ID = 5,
                    Name = "Safari Experience",
                    Layout = (Layout)1
                }
                );

            mb.Entity<Amenity>().HasData(
                new Amenity
                {
                    ID = 1,
                    Name = "Beachfront"
                },
                new Amenity
                {
                    ID = 2,
                    Name = "Vaulted Ceilings"
                },
                new Amenity
                {
                    ID = 3,
                    Name = "Air Conditioning"
                },
                new Amenity
                {
                    ID = 4,
                    Name = "Mini Keg"
                },
                new Amenity
                {
                    ID = 5,
                    Name = "Hottub"
                }
                );
        }


        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<RoomAmenity> RoomAmenities { get; set; }
    }
}
