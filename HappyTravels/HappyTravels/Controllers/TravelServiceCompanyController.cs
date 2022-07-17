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
    public class TravelServiceCompanyController : Controller
    {
        private readonly DataContext _context;

        public TravelServiceCompanyController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TravelServiceCompany>>> Get()
        {
            var buses = await _context.TravelServiceCompanies.Include(x => x.Buses)
                .Select(company => new
                {
                    company.Id,
                    company.Name,
                    company.Mobile,
                    Buses = company.Buses!.Select(bus => new { bus.Number, bus.TotalSeats }).ToList(),
                    TravelSchedules = company.TravelSchedules!.ToList()
                })
                .ToListAsync();

            return Ok(buses);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTravelServiceCompany(TravelServiceCompanyDto companyDto)
        {
            var newCompany = new TravelServiceCompany
            {
                Name = companyDto.Name,
                Mobile = companyDto.Mobile
            };

            _context.TravelServiceCompanies.Add(newCompany);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTravelServiceCompany(TravelServiceCompanyDto companyDto, int id)
        {
            var company = await _context.TravelServiceCompanies.FindAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            company.Name = companyDto.Name;
            company.Mobile = companyDto.Mobile;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTravelServiceCompany(int id)
        {
            var company = await _context.TravelServiceCompanies.FindAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            _context.TravelServiceCompanies.Remove(company);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}

