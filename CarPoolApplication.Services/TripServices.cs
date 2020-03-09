using System;
using System.Linq;
using System.Collections.Generic;
using CarPoolApplication.Models;
using System.Collections.ObjectModel;

namespace CarPoolApplication.Services
{
    public class TripServices
    {
        public void CreateTripOffer(string date, string time, string source, string destination, double distance, string carModel, string carNumber, int totalSeats, decimal totalCost, string username)
        {
            using (var db = new UserContext())
            {
                db.TripOffers.Add(new TripOffer(date, time, source, destination, distance, carModel, carNumber, totalSeats, totalCost, username));
                db.SaveChanges();
            }
        }

        public ICollection<TripOffer> SearchTrip(string date, string source, string destination)
        {
            ICollection<TripOffer> trips = new Collection<TripOffer>();
            using (var db = new UserContext())
            {
                trips = db.TripOffers
                          .Where(trip => trip.Date == date && trip.Source == source && trip.Destination == destination)
                          .ToList();
            }

            return trips;
        }

        public ICollection<TripOffer> ShowTripOffers(string username)
        {
            ICollection<TripOffer> trips = new Collection<TripOffer>();
            using (var db = new UserContext())
            {
                trips = db.TripOffers
                          .Where(trip => trip.Username == username)
                          .ToList();
            }
            return trips;
        }

        public void JoinRequest(string username, string tripOfferId)
        {
            using (var db = new UserContext())
            {
                TripOffer tripOffer = db.TripOffers
                             .Where(trip => trip.TripOfferId == tripOfferId)
                             .FirstOrDefault();

                db.TripRequests.Add(new TripRequest(tripOffer.Username, username, tripOffer.TripOfferId));
                db.SaveChanges();
            }

            
        }
    }
}
