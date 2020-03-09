using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarPoolApplication.Models
{
    public class TripOffer
    {
        [Key]
        public string TripOfferId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public double Distance { get; set; }
        public int TotalSeats { get; set; }
        public int SeatsOccupied { get; set; }
        public int SeatsLeft { get; set; }
        public decimal TotalCost { get; set; }
        public decimal CostPerHead { get; set; }
        public string CarModel { get; set; }
        public string  CarNumber { get; set; }

        public string Username { get; set; }
        
        
        
        public TripOffer(string date, string time, string source, string destination, double distance, string carModel, string carNumber, int totalSeats, decimal totalCost, string username)
        {
            TripOfferId = "TRIP" + DateTime.Now.ToString("mmss");
            this.Date = date;
            this.Time = time;
            this.Source = source;
            this.Destination = destination;
            this.Distance = distance;
            this.CarModel = carModel;
            this.CarNumber = carNumber;
            this.TotalSeats = totalSeats;
            this.SeatsOccupied = 1;
            this.SeatsLeft = TotalSeats - SeatsOccupied;
            this.TotalCost = totalCost;
            this.CostPerHead = TotalCost / TotalSeats;
            Username = username;            
        }

        public TripOffer() { }
    }
}
