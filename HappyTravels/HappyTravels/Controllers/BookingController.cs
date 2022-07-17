using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HappyTravels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HappyTravels.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : Controller
    {
        private readonly DataContext _context;

        public BookingController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> Get()
        {
            var bookings = await _context.Bookings.ToListAsync();

            return Ok(bookings);
        }

        [HttpPost]
        public async Task<ActionResult> CreateBooking(BookingDto booking)
        {
            var newBooking = new Booking
            {
                TravellerId = booking.TravellerId,
                TravelScheduleId = booking.TravelScheduleId,
                SeatNumber = booking.SeatNumber,
                IsPaid = booking.IsPaid
            };

            _context.Bookings.Add(newBooking);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBooking(BookingDto booking, int id)
        {
            var dbBooking = await _context.Bookings.FindAsync(id);

            if (dbBooking == null)
            {
                return NotFound();
            }

            dbBooking.TravellerId = booking.TravellerId;
            dbBooking.TravelScheduleId = booking.TravelScheduleId;
            dbBooking.SeatNumber = booking.SeatNumber;
            dbBooking.IsPaid = booking.IsPaid;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBooking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

