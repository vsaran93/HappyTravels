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
    public class BusController : Controller
    {
        private readonly DataContext _context;

        public BusController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bus>>> Get()
        {
            var buses = await _context.Buses.Include(x => x.TravelServiceCompany)
                .Select(bus => new
                {
                    bus.Id,
                    bus.Number,
                    bus.TotalSeats,
                    TravelServiceCompany = new
                    {
                        bus.TravelServiceCompany!.Name,
                        bus.TravelServiceCompany.Mobile
                    }
                })
                .ToListAsync();

            return Ok(buses);
        }

        [HttpPost]
        public async Task<ActionResult> CreateBus(BusDto busDto)
        {
            var newBus = new Bus
            {
                Number = busDto.Number,
                TotalSeats = busDto.TotalSeats,
                TravelServiceCompanyId = busDto.TravelServiceCompanyId
            };

            _context.Buses.Add(newBus);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBus(BusDto busDto, int id)
        {
            var dbBus = await _context.Buses.FindAsync(id);

            if (dbBus == null)
            {
                return NotFound();
            }

            dbBus.Number = busDto.Number;
            dbBus.TotalSeats = busDto.TotalSeats;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBus(int id)
        {
            var dbBus = await _context.Buses.FindAsync(id);

            if (dbBus == null)
            {
                return NotFound();
            }

            _context.Buses.Remove(dbBus);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

