using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace CarPoolApplication.Models
{
    public class UserContext : DbContext
    {
        public UserContext() : base() { }

        

        public DbSet<User> Users { get; set; }
        public DbSet<TripOffer> TripOffers { get; set; }
        public DbSet<TripBooking> TripBookings { get; set; }
        public DbSet<TripRequest> TripRequests { get; set; }


    }
}
