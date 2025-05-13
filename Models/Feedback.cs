using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Travel_and_Tourism.Models;

namespace Travel_and_Tourism.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }

        [Required]
        public int BookingId { get; set; }

        [ForeignKey("BookingId")]
        public Booking Booking { get; set; }

        [Required]
        public int TouristId { get; set; }

        [ForeignKey("TouristId")]
        public User Tourist { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        public string Comment { get; set; }

        public DateTime DateSubmitted { get; set; }
    }
}
