using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HappyTravels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HappyTravels.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TravellerController : Controller
    {
        private readonly DataContext _context;

        public TravellerController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Traveller>>> Get()
        {
            var travellers = await _context.Travellers.ToListAsync();

            return Ok(travellers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Traveller>> GetTraveller(int id)
        {
            var traveller = await _context.Travellers.FindAsync(id);

            if (traveller == null)
            {
                return NotFound();
            }

            return Ok(traveller);
        }

        [HttpPost]
        public async Task<ActionResult<Traveller>> CreateTraveller(Traveller traveller)
        {
            _context.Travellers.Add(traveller);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Traveller>> UpdateTraveller(Traveller traveller, int id)
        {
            var dbTraveller = await _context.Travellers.FindAsync(id);

            if (dbTraveller == null)
            {
                return BadRequest();
            }

            dbTraveller.FirstName = traveller.FirstName;
            dbTraveller.LastName = traveller.LastName;
            dbTraveller.Phone = traveller.Phone;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Traveller>> DeleteTraveller(int id)
        {
            var traveller = await _context.Travellers.FindAsync(id);

            if (traveller == null)
            {
                return NotFound();
            }

            _context.Travellers.Remove(traveller);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}