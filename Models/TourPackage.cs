using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http; // for IFormFile

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

        public string Duration { get; set; }


        public string AvailableDates { get; set; }

        public int MaxGroupSize { get; set; }

        public byte[] ImageUrl { get; set; }  // Properly closed property

        [NotMapped]
        public IFormFile ImageFile { get; set; }  // Separate property, not mapped to DB

        
    }
}
