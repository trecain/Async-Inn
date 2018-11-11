﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models
{
    public class RoomAmenity
    {
        // Room Amenity fields
        public int AmenityID { get; set; }
        public int RoomID { get; set; }

        // Navigation properties
        public Amenity Amenity { get; set; }
        public Room Room { get; set; }
    }
}
