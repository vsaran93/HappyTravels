using System;
namespace HappyTravels.Models
{
    public class Traveller
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public Booking? Booking { get; set; }
    }
}

