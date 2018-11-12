using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models
{
     public class Room
     {
        // Room properties
        public int ID { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public Layout Layout { get; set; }

        // Navigation properties
        public ICollection<HotelRoom> HotelRooms { get; set; }
        public ICollection<RoomAmenity> RoomAmenities { get; set; }
     }

     public enum Layout
     {
        Studio = 0,
        OneBedroom,
        TwoBedroom
     }
}
