using System;
namespace HappyTravels.Models
{
    public class TravelSchedule
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int BusId { get; set; }
        public string Destination { get; set; } = string.Empty;
        public string StartingPoint { get; set; } = string.Empty;
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public decimal Fare { get; set; }

        public TravelServiceCompany? TravelServiceCompany { get; set; }
        public Bus? Bus { get; set; }
        public IEnumerable<Booking>? Bookings { get; set; }
    }
}

