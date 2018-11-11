using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Async_Inn.Models
{
    public class Hotel
    {
        public int ID { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string Address { get; set; }
        [Phone]
        public string Phone { get; set; }

        // Navigation properties
        public ICollection<HotelRoom> HotelRooms { get; set; }
    }
}
