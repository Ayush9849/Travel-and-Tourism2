using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Travel_and_Tourism.ViewModels
{
    public class TourPackageViewModel
    {
        public int TourId { get; set; }

        [Required]
        public int AgencyId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        [Range(0, 10000)]
        public decimal Price { get; set; }

        public int Duration { get; set; }

        public string AvailableDates { get; set; }

        public int MaxGroupSize { get; set; }

        public IFormFile ImageFile { get; set; }

        public string ExistingImageUrl { get; set; }
    }

}
