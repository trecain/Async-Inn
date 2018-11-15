using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interfaces
{
    public interface IRoom
    {
        // IRoom interface required methods
        Task AddRoom(Room room);
        Task UpdateRoom(Room room);
        Task DeleteRoom(Room room);
        Task<IEnumerable<Room>> GetRooms();
        Task<Room> GetRoom(int? id);

        Task<RoomAmenity> GetRoomAmenities(int? AmenitiesID, int? RoomID);
    }
}
