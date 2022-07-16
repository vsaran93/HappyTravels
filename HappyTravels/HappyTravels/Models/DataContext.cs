using System;
using Microsoft.EntityFrameworkCore;

namespace HappyTravels.Models
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Traveller> Travellers { get; set; } = null!;
        public DbSet<TravelServiceCompany> TravelServiceCompanies { get; set; } = null!;
        public DbSet<TravelSchedule> TravelSchedules { get; set; } = null!;
        public DbSet<Booking> Bookings { get; set; } = null!;
        public DbSet<Bus> Buses { get; set; } = null!;
    }
}

