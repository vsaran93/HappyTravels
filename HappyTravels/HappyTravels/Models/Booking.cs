using System;
namespace HappyTravels.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int TravellerId { get; set; }
        public int TravelScheduleId { get; set; }
        public int SeatNumber { get; set; }
        public bool IsPaid { get; set; }

        public Traveller? Traveller { get; set; }
        public TravelSchedule? TravelSchedule { get; set; }
    }
}

