using System;
using Xunit;
using Async_Inn;
using Async_Inn.Data;
using Async_Inn.Models;
using Microsoft.EntityFrameworkCore;

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
    }
}
