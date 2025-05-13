using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Travel_and_Tourism.Models;

namespace Travel_and_Tourism.Models
{
    public class TourPackage
    {
        [Key]
        public int TourId { get; set; }

        [Required]
        public int AgencyId { get; set; }

        [ForeignKey("AgencyId")]
        public TravelAgency TravelAgency { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        [Range(0, 10000)]
        public decimal Price { get; set; }

        public int Duration { get; set; } // In days

        public string AvailableDates { get; set; }

        public int MaxGroupSize { get; set; }

        public string ImageUrl { get; set; }

        //public ICollection<Booking> Bookings { get; set; }
    }
}
