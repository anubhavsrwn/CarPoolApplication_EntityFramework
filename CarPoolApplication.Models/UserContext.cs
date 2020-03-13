using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity.ModelConfiguration.Conventions;
//using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
namespace CarPoolApplication.Models
{
    public class UserContext : DbContext
    {
        public UserContext() : base("CarPoolDB") { }


        public DbSet<User> Users { get; set; }
        public DbSet<TripOffer> TripOffers { get; set; }
        public DbSet<TripBooking> TripBookings { get; set; }
        public DbSet<TripRequest> TripRequests { get; set; }

        
    }
}
