using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interfaces
{
    public interface IHotel
    {
        // Hotel interface required methods
        Task AddHotel(Hotel hotel);
        Task UpdateHotel(Hotel hotel);
        Task DeleteHotel(int id);
        Task<IEnumerable<Hotel>> GetHotels();
        Task<Hotel> GetHotel(int? id);
        Task<HotelRoom> GetHotelRoom(int? HotelID, int? RoomID);
    }
}
