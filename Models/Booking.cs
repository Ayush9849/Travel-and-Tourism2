using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Travel_and_Tourism.Models;

namespace Travel_and_Tourism.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [Required]
        public int TourId { get; set; }

        [ForeignKey("TourId")]
        public TourPackage TourPackage { get; set; }

        [Required]
        public int TouristId { get; set; }

        [ForeignKey("UserId")]
        public User Tourist { get; set; }

        public DateTime BookingDate { get; set; }

        public string Status { get; set; } // Pending, Confirmed, Completed

        public string PaymentStatus { get; set; }

        public Feedback Feedback { get; set; }
    }
}
