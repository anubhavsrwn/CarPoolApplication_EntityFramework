using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace CarPoolApplication.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }

        public ICollection<TripOffer> TripOffers { get; set; } = new Collection<TripOffer>();
        public ICollection<TripBooking> TripBookings { get; set; } = new Collection<TripBooking>();


        public User(string username, string Password)
        {
            this.Username = username;
            this.Password = Password;
        }

        public User() { }
        
        public void ShowUser()
        {
            Console.WriteLine("Username : " + Username + " | Password :  " + Password);
        }
    
    }
}
