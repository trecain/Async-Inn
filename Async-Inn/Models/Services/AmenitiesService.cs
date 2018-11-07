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
        private HotelDbContext _context;

        public AmenitiesService(HotelDbContext context)
        {
            _context = context;
        }

        public async Task AddAmenity(Amenity amenities)
        {
            _context.Amenities.Add(amenities);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAmenity(int id)
        {
            Amenity amenities = await GetAmenity(id);
            _context.Amenities.Remove(amenities);
            await _context.SaveChangesAsync();
        }

        public async Task<Amenity> GetAmenity(int? id)
        {
            return await _context.Amenities.FirstOrDefaultAsync(amenities => amenities.ID == id);
        }

        public async Task<List<Amenity>> GetAmenities()
        {
            return await _context.Amenities.ToListAsync();
        }

        public async Task UpdateAmenity(Amenity amenities)
        {
            _context.Amenities.Update(amenities);
            await _context.SaveChangesAsync();
        }

    }
}
