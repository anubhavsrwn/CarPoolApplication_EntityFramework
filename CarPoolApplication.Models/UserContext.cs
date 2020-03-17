using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CarPoolApplication.Models
{
    public class UserContext : DbContext
    {
        public UserContext() : base() { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CarPoolApplicationDB;Trusted_Connection=True;");
        }


        public DbSet<User> Users { get; set; }
        public DbSet<TripOffer> TripOffers { get; set; }
        public DbSet<TripBooking> TripBookings { get; set; }
        public DbSet<TripRequest> TripRequests { get; set; }

        
    }
}
