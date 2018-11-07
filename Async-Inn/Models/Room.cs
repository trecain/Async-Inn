using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models
{
     public class Room
     {
        public int ID { get; set; }
        public string Name { get; set; }
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
