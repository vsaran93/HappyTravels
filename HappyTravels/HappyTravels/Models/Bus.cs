using System;
namespace HappyTravels.Models
{
    public class Bus
    {
        public int Id { get; set; }
        public string? Number { get; set; }
        public int TotalSeats { get; set; }
        public int TravelServiceCompanyId { get; set; }

        public TravelServiceCompany? TravelServiceCompany { get; set; }
        public TravelSchedule? TravelSchedule { get; set; }
    }
}

