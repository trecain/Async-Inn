using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Async_Inn.Models.Interfaces;
using Async_Inn.Data;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn.Models.Services
{
    public class RoomService : IRoom
    {
        /// <summary>
        /// brings in db context for the service
        /// </summary>
        private HotelDbContext _context;

        public RoomService(HotelDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// adds a hotel room
        /// </summary>
        /// <param name="room">hotel room to be added</param>
        /// <returns></returns>
        public async Task AddRoom(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
        }


        /// <summary>
        /// deletes hotel room
        /// </summary>
        /// <param name="id">room id to delete</param>
        /// <returns></returns>
        public async Task DeleteRoom(Room room)
        {
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }


        /// <summary>
        /// gets the rooms 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Room> GetRoom(int? id)
        {
            return await _context.Rooms.FirstOrDefaultAsync(room => room.ID == id);
        }


        /// <summary>
        /// gets the room amenities from the db
        /// </summary>
        /// <param name="amenitiesID"></param>
        /// <param name="roomID"></param>
        /// <returns></returns>
        public async Task<RoomAmenity> GetRoomAmenities(int? amenitiesID, int? roomID)
        {
            return await _context.RoomAmenities
                .Include(x => x.Room)
                .Include(x => x.Amenity)
                .FirstOrDefaultAsync(x => x.AmenityID == amenitiesID && x.RoomID == roomID);
        }


        /// <summary>
        /// returns a list of all the rooms
        /// </summary>
        /// <returns>list of rooms</returns>
        public async Task<IEnumerable<Room>> GetRooms()
        {
            return await _context.Rooms.ToListAsync();
        }


        /// <summary>
        /// Updates the room
        /// </summary>
        /// <param name="room">room to be updateds</param>
        /// <returns></returns>
        public async Task UpdateRoom(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }
    }
}
