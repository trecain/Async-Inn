using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Async_Inn.Data;
using Async_Inn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Async_Inn.Models.Interfaces;

namespace Async_Inn.Controllers
{
    public class HotelRoomsController : Controller
    {
        /// <summary>
        /// brings in Ihotel interface and db context
        /// </summary>
        private readonly HotelDbContext _context;
        private readonly IHotel _hotel; 

        public HotelRoomsController(HotelDbContext context, IHotel hotel)
        {
            _context = context;
            _hotel = hotel;
        }

        // GET: HotelRooms
        public async Task<IActionResult> Index()
        {
            var asyncInnDbContext = _context.HotelRooms.Include(h => h.Hotel).Include(h => h.Room);
            return View(await asyncInnDbContext.ToListAsync());
        }

        // GET: HotelRooms/Details/5
        public async Task<IActionResult> Details(int? hotelID, int? roomID)
        {
            if (hotelID == null || roomID == null)
            {
                return NotFound();
            }

            var hotelRoom = await _hotel.GetHotelRoom(hotelID, roomID);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            return View(hotelRoom);
        }

        // GET: HotelRooms/Create
        public IActionResult Create()
        {
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "Name");
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name");
            return View();
        }

        // POST: HotelRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotelID,RoomID,RoomNumber,Rate,PetFriendly")] HotelRoom hotelRoom)
        {
            if (_context.HotelRooms.Any(hr => hr.RoomNumber == hotelRoom.RoomNumber))
            {
                ModelState.AddModelError("", $"{hotelRoom.RoomNumber} already exists.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(hotelRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "Name", hotelRoom.HotelID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name", hotelRoom.RoomID);
            return View(hotelRoom);
        }

        // GET: HotelRooms/Edit/5
        public async Task<IActionResult> Edit(int? hotelID, int? roomID)
        {
            if (hotelID == null || roomID == null)
            {
                return NotFound();
            }

            var hotelRoom = await _hotel.GetHotelRoom(hotelID, roomID);
            if (hotelRoom == null)
            {
                return NotFound();
            }
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "Name", hotelRoom.HotelID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name", hotelRoom.RoomID);
            return View(hotelRoom);
        }

        // POST: HotelRooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int hotelID, int roomID, [Bind("HotelID,RoomID,RoomNumber,Rate,PetFriendly")] HotelRoom hotelRoom)
        {
            if (hotelID != hotelRoom.HotelID || roomID == hotelRoom.RoomID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelRoom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelRoomExists(hotelRoom.HotelID, hotelRoom.RoomID))
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
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "Name", hotelRoom.HotelID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name", hotelRoom.RoomID);
            return View(hotelRoom);
        }

        // GET: HotelRooms/Delete/5
        public async Task<IActionResult> Delete(int? hotelID, int? roomID)
        {
            if (hotelID == null || roomID == null)
            {
                return NotFound();
            }

            var hotelRoom = await _hotel.GetHotelRoom(hotelID, roomID);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            return View(hotelRoom);
        }

        // POST: HotelRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int hotelID, int roomID)
        {
            var hotelRoom = await _hotel.GetHotelRoom(hotelID, roomID);
            _context.HotelRooms.Remove(hotelRoom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelRoomExists(int hotelID, int roomID)
        {
            return _context.HotelRooms.Any(e => e.HotelID == hotelID && e.RoomID == roomID);
        }
    }
}

