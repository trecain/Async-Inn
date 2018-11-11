using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Async_Inn.Data;
using Async_Inn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn.Models.Services
{
    public class AmenitiesService : IAmenities
    {
        // pulls in db context for service
        private HotelDbContext _context;

        public AmenitiesService(HotelDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Adds an amenity
        /// </summary>
        /// <param name="amenities">Amenity to add</param>
        /// <returns></returns>
        public async Task AddAmenity(Amenity amenities)
        {
            _context.Amenities.Add(amenities);
            await _context.SaveChangesAsync();
        }


        /// <summary>
        /// Deletes an amenity
        /// </summary>
        /// <param name="id">Id of the amenity that needs to be deleted</param>
        /// <returns></returns>
        public async Task DeleteAmenity(int id)
        {
            Amenity amenities = await _context.Amenities.FirstOrDefaultAsync(x => x.ID == id);
            _context.Amenities.Remove(amenities);
            await _context.SaveChangesAsync();
        }


        /// <summary>
        /// returns specific amenity
        /// </summary>
        /// <param name="id">list of amenities</param>
        /// <returns></returns>
        public async Task<Amenity> GetAmenity(int? id)
        {
            return await _context.Amenities.FirstOrDefaultAsync( x => x.ID == id);
        }


        /// <summary>
        /// returns a list with all the amenities
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Amenity>> GetAmenities()
        {
            return await _context.Amenities.ToListAsync();
        }


        /// <summary>
        /// updates the amenity
        /// </summary>
        /// <param name="amenities">amenity that needs to be updated</param>
        /// <returns></returns>
        public async Task UpdateAmenity(Amenity amenities)
        {
            _context.Update(amenities);
            await _context.SaveChangesAsync();
        }

    }
}
