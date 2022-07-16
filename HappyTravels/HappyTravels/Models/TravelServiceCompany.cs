using System;
namespace HappyTravels.Models
{
    public class TravelServiceCompany
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Mobile { get; set; }

        public IEnumerable<Bus>? Buses { get; set; }
        public IEnumerable<TravelSchedule>? TravelSchedules { get; set; }
    }
}

