using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Travel_and_Tourism.Models;

namespace Travel_and_Tourism.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<TravelAgency> TravelAgencies { get; set; }
        public DbSet<TourPackage> TourPackages { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
 
        public DbSet<RegisteredUser> RegisteredUsers { get; set; }

    }
}
