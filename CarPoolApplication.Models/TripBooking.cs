 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarPoolApplication.Models
{
    public class TripBooking
    {
        [Key]
        public string TripBookingId { get; set; }
        public string TripOfferId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public double Distance { get; set; }
        public decimal CostPerHead { get; set; }
        public string Passenger { get; set; }
        public string Username { get; set; }
        public TripBooking() {}
        
        
        public TripBooking(string tripOfferId, string date, string time, string source, string destination, double distance, decimal costPerHead, string username, string passenger)
        {
            TripBookingId = "TRIPB" + DateTime.Now.ToString("mmss");
            TripOfferId = tripOfferId;
            Date = date;
            Time = time;
            Source = source;
            Destination = destination;
            Distance = distance;
            CostPerHead = costPerHead;
            Username = username;
            Passenger = passenger;
        }
    }
}
