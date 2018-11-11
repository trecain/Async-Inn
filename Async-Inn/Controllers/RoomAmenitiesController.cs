using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Async_Inn.Data;
using Async_Inn.Models;
using Async_Inn.Models.Interfaces;

namespace Async_Inn.Controllers
{
    public class RoomAmenitiesController : Controller
    {
        private readonly HotelDbContext _context;
        private readonly IRoom _room; 

        public RoomAmenitiesController(HotelDbContext context, IRoom room)
        {
            _context = context;
            _room = room;
        }

        // GET: RoomAmenities
        public async Task<IActionResult> Index()
        {
            var asyncInnDbContext = _context.RoomAmenities.Include(r => r.Amenity).Include(r => r.Room);
            return View(await asyncInnDbContext.ToListAsync());
        }

        // GET: RoomAmenities/Details/5
        public async Task<IActionResult> Details(int? amenitiesID, int? roomID)
        {
            if (amenitiesID == null && roomID == null)
            {
                return NotFound();
            }

            var roomAmenity = await _room.GetRoomAmenities(amenitiesID, roomID);
            if (roomAmenity == null)
            {
                return NotFound();
            }

            return View(roomAmenity);
        }

        // GET: RoomAmenities/Create
        public IActionResult Create()
        {
            ViewData["AmenityID"] = new SelectList(_context.Amenities, "ID", "Name");
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name");
            return View();
        }

        // POST: RoomAmenities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AmenityID,RoomID")] RoomAmenity roomAmenity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomAmenity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AmenityID"] = new SelectList(_context.Amenities, "ID", "Name", roomAmenity.AmenityID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name", roomAmenity.RoomID);
            return View(roomAmenity);
        }

        // GET: RoomAmenities/Edit/5
        public async Task<IActionResult> Edit(int? amenityID, int? roomID)
        {
            if (amenityID == null && roomID == null)
            {
                return NotFound();
            }

            var roomAmenity = await _room.GetRoomAmenities(amenityID, roomID);
            if (roomAmenity == null)
            {
                return NotFound();
            }
            ViewData["AmenityID"] = new SelectList(_context.Amenities, "ID", "Name", roomAmenity.AmenityID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name", roomAmenity.RoomID);
            return View(roomAmenity);
        }

        // POST: RoomAmenities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AmenityID,RoomID")] RoomAmenity roomAmenity)
        {
            if (id != roomAmenity.AmenityID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomAmenity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomAmenityExists(roomAmenity.AmenityID, roomAmenity.RoomID))  
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AmenityID"] = new SelectList(_context.Amenities, "ID", "Name", roomAmenity.AmenityID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name", roomAmenity.RoomID);
            return View(roomAmenity);
        }

        // GET: RoomAmenities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomAmenity = await _context.RoomAmenities
                .Include(r => r.Amenity)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.AmenityID == id);
            if (roomAmenity == null)
            {
                return NotFound();
            }
            return View(roomAmenity);
        }

        // POST: RoomAmenities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomAmenity = await _context.RoomAmenities.FindAsync(id);
            _context.RoomAmenities.Remove(roomAmenity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomAmenityExists(int amenitiesID, int roomID)
        {
            return _context.RoomAmenities.Any( x => x.AmenityID == amenitiesID && x.RoomID == roomID);
        }
    }
}

