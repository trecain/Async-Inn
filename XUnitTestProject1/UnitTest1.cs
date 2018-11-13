using System;
using Xunit;
using Async_Inn;
using Async_Inn.Data;
using Async_Inn.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System.Linq;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        /// <summary>
        /// checks that we can set and get room props
        /// </summary>
        [Fact]
        public void CanGetAndSetRoom()
        {
            Room room = new Room();
            room.Name = "Love Shack";
            room.Layout = Layout.OneBedroom;
            Assert.Equal("Love Shack", room.Name);
            Assert.Equal(Layout.OneBedroom, room.Layout);
        }


        /// <summary>
        /// checks that we can set and get hotel props
        /// </summary>
        [Fact]
        public void CanGetAndSetHotel()
        {
            Hotel hotel = new Hotel();
            hotel.Name = "Motel 6";
            hotel.Address = "155 no love";
            hotel.Phone = "909-657-8906";
            Assert.Equal("Motel 6", hotel.Name);
            Assert.Equal("155 no love", hotel.Address);
            Assert.Equal("909-657-8906", hotel.Phone);
        }


        /// <summary>
        /// checks that we can set and get hotel room props
        /// </summary>
        [Fact]
        public void CanGetAndSetHotelRoom()
        {
            Hotel hotel = new Hotel();
            HotelRoom hr = new HotelRoom();
            Room room = new Room();
            hr.Room = room;
            hr.Hotel = hotel;
            hr.PetFriendly = false;
            hr.RoomNumber = 33;
            Assert.Equal(room, hr.Room);
            Assert.Equal(hotel, hr.Hotel);
            Assert.False(hr.PetFriendly);
            Assert.Equal(33, hr.RoomNumber);
        }


        /// <summary>
        /// checks that we can set and get room amenity
        /// </summary>
        [Fact]
        public void CanGetAndSetAmenity()
        {
            RoomAmenity ra = new RoomAmenity();
            Amenity amenity = new Amenity();
            amenity.Name = "Ice Box";
            ra.Amenity = amenity;
            Assert.Equal(amenity, ra.Amenity);
        }


        /// <summary>
        /// checks that a hotel can be saved to the database
        /// </summary>
        [Fact]
        public async void CanSaveHotelInDB()
        {
            DbContextOptions<HotelDbContext> options =
                new DbContextOptionsBuilder<HotelDbContext>().UseInMemoryDatabase("DbSaves").Options;

            using (HotelDbContext context = new HotelDbContext(options))
            {
                Hotel hotel = new Hotel();
                hotel.Name = "Motel 6";
                context.Hotels.Add(hotel);
                context.SaveChanges();

                var nameOfHotel = await context.Hotels.FirstOrDefaultAsync();
                Assert.Equal("Motel 6", nameOfHotel.Name);
            }
        }


        /// <summary>
        /// can delete hotel from database
        /// </summary>
        [Fact]
        public async void CanDeleteHotelFromDB()
        {
            DbContextOptions<HotelDbContext> options = 
                new DbContextOptionsBuilder<HotelDbContext>().UseInMemoryDatabase("DbDeletes").Options;

            using (HotelDbContext context = new HotelDbContext(options))
            {
                // Arrange
                Hotel hotel = new Hotel();
                hotel.Name = "Motel 6";
                context.Hotels.Add(hotel);
                context.SaveChanges();

                // Act
                context.Hotels.Remove(hotel);
                context.SaveChanges();

                var hotelName = await context.Hotels.FirstOrDefaultAsync();
                
                // Assert
                Assert.False(context.Hotels.Any());
            }
        }


        /// <summary>
        /// can update the hotel in database.
        /// </summary>
        [Fact]
        public async void CanUpdateHotelInDB()
        {
            // Setup our database
            // Set values
            DbContextOptions<HotelDbContext> options = new DbContextOptionsBuilder<HotelDbContext>().UseInMemoryDatabase("DbCanUpdate").Options;

            using (HotelDbContext context = new HotelDbContext(options))
            {
                // Arrange
                Hotel hotel = new Hotel();
                hotel.Name = "Motel 6";
                context.Hotels.Add(hotel);
                context.SaveChanges();

                // Act
                hotel.Name = "Motel 7";
                context.Hotels.Update(hotel);

                var hotelName = await context.Hotels.FirstOrDefaultAsync();

                // Assert
                Assert.Equal("Motel 7", hotelName.Name);
            }

        }


        /// <summary>
        /// checks amenity can get saved to the database
        /// </summary>
        [Fact]
        public async void CanSaveAmenityToDB()
        {
            DbContextOptions<HotelDbContext> options = 
                new DbContextOptionsBuilder<HotelDbContext>().UseInMemoryDatabase("DbSaveAmenity").Options;

            using (HotelDbContext context = new HotelDbContext(options))
            {
                // Arrange
                Amenity amenity = new Amenity();
                amenity.Name = "Ice Box";
                context.Amenities.Add(amenity);
                context.SaveChanges();

                // Act
                var amenityName = await context.Amenities.FirstOrDefaultAsync();

                // Assert
                Assert.Equal("Ice Box", amenityName.Name);
            }
        }


        /// <summary>
        /// can delete hotel in database
        /// </summary>
        [Fact]
        public async void CanDeleteAmenityFromDB()
        {
            DbContextOptions<HotelDbContext> options = 
                new DbContextOptionsBuilder<HotelDbContext>().UseInMemoryDatabase("DbDeleteAmenity").Options;

            using (HotelDbContext context = new HotelDbContext(options))
            {
                // Arrange
                Amenity amenity = new Amenity();
                amenity.Name = "Ice Box";
                context.Amenities.Add(amenity);
                context.SaveChanges();

                // Act
                context.Amenities.Remove(amenity);
                context.SaveChanges();

                var amenityName = await context.Amenities.FirstOrDefaultAsync();

                // Assert
                Assert.False(context.Amenities.Any());
            }
        }


        /// <summary>
        /// can update the hotel in database.
        /// </summary>
        [Fact]
        public async void CanUpdateAmenityInDB()
        {
            DbContextOptions<HotelDbContext> options = 
                new DbContextOptionsBuilder<HotelDbContext>().UseInMemoryDatabase("DbUpdateAmenity").Options;

            using (HotelDbContext context = new HotelDbContext(options))
            {
                // Arrange
                Amenity amenity = new Amenity();
                amenity.Name = "Ice Box";
                context.Amenities.Add(amenity);
                context.SaveChanges();

                // Act
                amenity.Name = "Coffee Machine";
                context.Amenities.Update(amenity);

                var amenityName = await context.Amenities.FirstOrDefaultAsync();

                // Assert
                Assert.Equal("Coffee Machine", amenityName.Name);
            }
        }


        /// <summary>
        /// can save room in database
        /// </summary>
        [Fact]
        public async void CanSaveRoomInDB()
        {
            DbContextOptions<HotelDbContext> options = 
                new DbContextOptionsBuilder<HotelDbContext>().UseInMemoryDatabase("DbSaveRoom").Options;

            using (HotelDbContext context = new HotelDbContext(options))
            {
                // Arrange
                Room room = new Room();
                room.Name = "Love Shack";
                room.Layout = Layout.Studio;
                context.Rooms.Add(room);
                context.SaveChanges();

                // Act
                var RoomName = await context.Rooms.FirstOrDefaultAsync();

                // Assert
                Assert.Equal("Love Shack", RoomName.Name);
                Assert.Equal(Layout.Studio, RoomName.Layout);
            }
        }


        /// <summary>
        /// can delete room from the database
        /// </summary>
        [Fact]
        public async void CanDeleteRoomInDB()
        {
            DbContextOptions<HotelDbContext> options = 
                new DbContextOptionsBuilder<HotelDbContext>().UseInMemoryDatabase("DbDeleteRoom").Options;

            using (HotelDbContext context = new HotelDbContext(options))
            {
                // Arrange
                Room room = new Room();
                room.Name = "Lovers Paradise";
                room.Layout = Layout.OneBedroom;
                context.Rooms.Add(room);
                context.SaveChanges();

                // Act
                context.Rooms.Remove(room);
                context.SaveChanges();

                var roomName = await context.Rooms.FirstOrDefaultAsync();

                // Assert
                Assert.False(context.Rooms.Any());
            }
        }


        /// <summary>
        /// can update the room in the DB
        /// </summary>
        [Fact]
        public async void CanUpdateRoomInDB()
        {
            DbContextOptions<HotelDbContext> options =
                new DbContextOptionsBuilder<HotelDbContext>().UseInMemoryDatabase("DbUpdateRoom").Options;

            using (HotelDbContext context = new HotelDbContext(options))
            {
                // Arrange
                Room room = new Room();
                room.Name = "The Cave";
                room.Layout = Layout.TwoBedroom;
                context.Rooms.Add(room);
                context.SaveChanges();

                // Act
                room.Name = "Pearl Love";
                context.Rooms.Update(room);

                var roomName = await context.Rooms.FirstOrDefaultAsync();

                // Assert
                Assert.Equal("Pearl Love", roomName.Name);
                Assert.Equal(Layout.TwoBedroom, roomName.Layout);
            }
        }


        /// <summary>
        /// can save room amenity in DB
        /// </summary>
        [Fact]
        public async void CanSaveRoomAmenityInDB()
        {
            DbContextOptions<HotelDbContext> options = 
                new DbContextOptionsBuilder<HotelDbContext>().UseInMemoryDatabase("DbSaveRoomAmenity").Options;

            using (HotelDbContext context = new HotelDbContext(options))
            {

                Room room = new Room();
                room.Name = "Cove";
                room.Layout = Layout.OneBedroom;
                context.Rooms.Add(room);

                Amenity amenity = new Amenity();
                amenity.Name = "Mini Bar";
                context.Amenities.Add(amenity);

                // Arrange
                RoomAmenity roomAmenity = new RoomAmenity();
                roomAmenity.Room = room;
                roomAmenity.Amenity = amenity;
                context.RoomAmenities.Add(roomAmenity);

                context.SaveChanges();

                // Act
                var roomAmenityGet = await context.RoomAmenities.FirstOrDefaultAsync();

                // Assert
                Assert.Equal(amenity, roomAmenityGet.Amenity);
            }
        }


        /// <summary>
        /// can delete room amenity in DB
        /// </summary>
        [Fact]
        public async void CanDeleteRoomAmenityInDB()
        {
            DbContextOptions<HotelDbContext> options = 
                new DbContextOptionsBuilder<HotelDbContext>().UseInMemoryDatabase("DbDeleteRoomAmenity").Options;

            using (HotelDbContext context = new HotelDbContext(options))
            {
                Room room = new Room();
                room.Name = "Cove";
                room.Layout = Layout.Studio;
                context.Rooms.Add(room);

                Amenity amenity = new Amenity();
                amenity.Name = "Mini Bar";
                context.Amenities.Add(amenity);

                // Arrange
                RoomAmenity roomAmenity = new RoomAmenity();
                roomAmenity.Room = room;
                roomAmenity.Amenity = amenity;
                context.RoomAmenities.Add(roomAmenity);
                context.SaveChanges();

                // Act
                context.RoomAmenities.Remove(roomAmenity);
                context.SaveChanges();

                var nameOfRoomAmenity = await context.RoomAmenities.FirstOrDefaultAsync();

                // Assert
                Assert.False(context.RoomAmenities.Any());
            }
        }


        /// <summary>
        /// can update room amenity in DB
        /// </summary>
        [Fact]
        public async void CanUpdateRoomAmenityInDB()
        {
            DbContextOptions<HotelDbContext> options = 
                new DbContextOptionsBuilder<HotelDbContext>().UseInMemoryDatabase("DbUpdateRoomAmenity").Options;

            using (HotelDbContext context = new HotelDbContext(options))
            {
                Room room = new Room();
                room.Name = "Cove";
                room.Layout = Layout.OneBedroom;
                context.Rooms.Add(room);

                Amenity amenityOne = new Amenity();
                amenityOne.Name = "Mini Bar";
                context.Amenities.Add(amenityOne);

                Amenity amenityTwo = new Amenity();
                amenityTwo.Name = "Cigars";
                context.Amenities.Add(amenityTwo);

                // Arrange
                RoomAmenity roomAmenity = new RoomAmenity();
                roomAmenity.Room = room;
                roomAmenity.Amenity = amenityOne;

                // Act
                roomAmenity.Amenity = amenityTwo;
                context.RoomAmenities.Update(roomAmenity);
                context.SaveChanges();

                var nameOfRoomAmenity = await context.RoomAmenities.FirstOrDefaultAsync();

                // Assert
                Assert.Equal(amenityTwo, nameOfRoomAmenity.Amenity);
            }
        }


        /// <summary>
        /// can save hotel room in DB
        /// </summary>
        [Fact]
        public async void CanSaveHotelRoomInDB()
        {
            DbContextOptions<HotelDbContext> options = 
                new DbContextOptionsBuilder<HotelDbContext>().UseInMemoryDatabase("DbSaveHotelRoom").Options;

            using (HotelDbContext context = new HotelDbContext(options))
            {
                Hotel hotel = new Hotel();
                hotel.Name = "Motel 6";
                context.Hotels.Add(hotel);

                Room room = new Room();
                room.Name = "Cove";
                room.Layout = Layout.Studio;
                context.Rooms.Add(room);

                // Arrange
                HotelRoom hotelRoom = new HotelRoom();
                hotelRoom.Room = room;
                hotelRoom.RoomNumber = 33;
                context.HotelRooms.Add(hotelRoom);

                context.SaveChanges();

                // Act
                var getHotelRooms = await context.HotelRooms.FirstOrDefaultAsync();

                // Assert
                Assert.Equal(33, getHotelRooms.RoomNumber);
            }
        }


        /// <summary>
        /// can delete hotel room in DB
        /// </summary>
        [Fact]
        public void CanDeleteHotelRoomFromDB()
        {
            DbContextOptions<HotelDbContext> options =
                new DbContextOptionsBuilder<HotelDbContext>().UseInMemoryDatabase("DbDeleteHotelRoom").Options;

            using (HotelDbContext context = new HotelDbContext(options))
            {
                Hotel hotel = new Hotel();
                hotel.Name = "Motel 6";
                context.Hotels.Add(hotel);

                Room room = new Room();
                room.Name = "Lovers Coral";
                room.Layout = Layout.OneBedroom;
                context.Rooms.Add(room);


                // Arrange
                HotelRoom hotelRoom = new HotelRoom();
                hotelRoom.Room = room;
                hotelRoom.RoomNumber = 13;
                context.HotelRooms.Add(hotelRoom);

                context.SaveChanges();

                // Act
                context.HotelRooms.Remove(hotelRoom);
                context.SaveChanges();

                // Assert
                Assert.False(context.HotelRooms.Any());
            }
        }


        /// <summary>
        /// can update the hotel room in the DB
        /// </summary>
        [Fact]
        public async void UpdateHotelRoomInDb()
        {
            DbContextOptions<HotelDbContext> options = 
                new DbContextOptionsBuilder<HotelDbContext>().UseInMemoryDatabase("DbUpdateHotelRoom").Options;

            using (HotelDbContext context = new HotelDbContext(options))
            {
                Hotel hotel = new Hotel();
                hotel.Name = "Motel 6";
                context.Hotels.Add(hotel);

                Room room = new Room();
                room.Name = "Cove";
                room.Layout = Layout.TwoBedroom;
                context.Rooms.Add(room);

                // Arrange
                HotelRoom hotelRoom = new HotelRoom();
                hotelRoom.Room = room;
                hotelRoom.RoomNumber = 78;
                context.HotelRooms.Add(hotelRoom);
                context.SaveChanges();

                // Act
                context.HotelRooms.Update(hotelRoom);
                context.SaveChanges();

                var GetHotelRooms = await context.HotelRooms.FirstOrDefaultAsync();

                // Assert
                Assert.Equal(78, GetHotelRooms.RoomNumber);
            }
        }
    }
}

    

