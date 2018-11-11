using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Async_Inn.Models
{
    public class Amenity
    {
        // Amenity field
        public int ID { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        // Navigation properties
        public ICollection<RoomAmenity> RoomAmenities { get; set; }
    }
}
