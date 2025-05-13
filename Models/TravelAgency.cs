using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Travel_and_Tourism.Models;

namespace Travel_and_Tourism.Models
{
    public class TravelAgency
    {
        [Key]
        public int AgencyId { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        public string AgencyName { get; set; }

        public string ServicesOffered { get; set; }

        public string ProfileImage { get; set; }

        public ICollection<TourPackage> TourPackages { get; set; }
    }
}
