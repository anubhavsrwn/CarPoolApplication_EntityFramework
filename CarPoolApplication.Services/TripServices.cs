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

        public void JoinTripRequest(string username, string tripOfferId)
        {
            using (var db = new UserContext())
            {
                TripOffer tripOffer = db.TripOffers
                                        .FirstOrDefault(trip => trip.TripOfferId == tripOfferId);
                             

                db.TripRequests.Add(new TripRequest(tripOffer.Username, username, tripOffer.TripOfferId));
                db.SaveChanges();
            }

        }

        public ICollection<TripRequest> ShowTripJoiningRequests(string username)
        {
            ICollection<TripRequest> trips = new Collection<TripRequest>();
            using (var db = new UserContext())
            {
                trips = db.TripRequests
                          .Where(trip => trip.TripCreater == username)
                          .ToList();
            }
            return trips;
        }

        public void ApproveTripJoinRequest(string requestId)
        {
            using (var db = new UserContext())
            {
                var tripRequest = db.TripRequests
                                    .First(trip => trip.RequestId == requestId);

                string tripOfferId = tripRequest.TripOfferId;
                string passenger = tripRequest.TripPassenger;
                TripOffer tripDetails = db.TripOffers.First(trip => trip.TripOfferId == tripOfferId);
                tripDetails.SeatsLeft--;
                tripDetails.SeatsOccupied++;
                db.SaveChanges();
                
                db.TripBookings.Add(new TripBooking(tripDetails.TripOfferId, tripDetails.Date, tripDetails.Time, tripDetails.Source, tripDetails.Destination, tripDetails.Distance, tripDetails.CostPerHead, tripDetails.Username, passenger));
                db.SaveChanges();


                var req = db.TripRequests.First(request => request.RequestId == requestId);
                db.TripRequests.Remove(req);
                db.SaveChanges();


            }
        }

        public ICollection<TripBooking> ShowTripBookings(string username)
        {
            ICollection<TripBooking> trips = new Collection<TripBooking>();
            using (var db = new UserContext())
            {
                trips = db.TripBookings
                          .Where(trip => trip.Username == username || trip.Passenger == username)
                          .ToList();
            }

            return trips;
        }
    }
}
