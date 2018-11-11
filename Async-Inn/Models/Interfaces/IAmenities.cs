using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interfaces
{
    public interface IAmenities
    {
        // IAmenities interface required methods
        Task AddAmenity(Amenity amenity);
        Task UpdateAmenity(Amenity amenity);
        Task DeleteAmenity(int id);
        Task<IEnumerable<Amenity>> GetAmenities();
        Task<Amenity> GetAmenity(int? id);
    }
}
