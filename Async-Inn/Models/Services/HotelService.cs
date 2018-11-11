using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Async_Inn.Models.Interfaces;
using Async_Inn.Data;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn.Models.Interfaces
{
    public class HotelService : IHotel
    {
        /// <summary>
        /// pulls in db context
        /// </summary>
        private HotelDbContext _context;

        public HotelService(HotelDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Adds hotel
        /// </summary>
        /// <param name="hotel">hotel to be added</param>
        /// <returns></returns>
        public async Task AddHotel(Hotel hotel)
        {
            _context.Add(hotel);
            await _context.SaveChangesAsync();
        }


        /// <summary>
        /// Deletes the hotel
        /// </summary>
        /// <param name="id">hotel to be deleted</param>
        /// <returns></returns>
        public async Task DeleteHotel(int id)
        {
            Hotel hotel = await GetHotel(id);
            _context.Remove(hotel);
            await _context.SaveChangesAsync();
        }


        /// <summary>
        /// returns list of hotels
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Hotel> GetHotel(int? id)
        {
            return await _context.Hotels.FirstOrDefaultAsync(hotel => hotel.ID == id);
        }


        /// <summary>
        /// returns hotel room model
        /// </summary>
        /// <param name="hotelID"></param>
        /// <param name="roomID"></param>
        /// <returns></returns>
        public async Task<HotelRoom> GetHotelRoom(int? hotelID, int? roomID)
        {
            return await _context.HotelRooms
                .Include(x => x.Hotel)
                .Include(x => x.Room)
                .FirstOrDefaultAsync(x => x.HotelID == hotelID && x.RoomID == roomID);
        }


        /// <summary>
        /// returns a specific hotel
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Hotel>> GetHotels()
        {
            return await _context.Hotels.ToListAsync();
        }


        /// <summary>
        /// updates the specific hotel
        /// </summary>
        /// <param name="hotel">The hotel to update</param>
        public async Task UpdateHotel(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            await _context.SaveChangesAsync();
        }
    }
}
