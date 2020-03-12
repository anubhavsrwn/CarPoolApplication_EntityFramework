using CarPoolApplication.Models;
using CarPoolApplication.Services;
using System;
using System.Collections.Generic;

namespace CarPoolApplication.UI
{
    class Program
    {
        UserServices UserServices = new UserServices();
        TripServices TripServices = new TripServices();
        
        void Main(string[] args)
        {
            MainMenu();
        }

        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Main Menu : ");
            Console.WriteLine("1. Log In.");
            Console.WriteLine("2. Sign Up");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
                        Console.Clear();
                        string username;
                        string password;
                        Console.WriteLine("Enter User Name : ");
                        username = Console.ReadLine();
                        Console.WriteLine("Enter Password : ");
                        password = Console.ReadLine();

                        if (UserServices.ValidateUser(username, password) == false)
                        {
                            Console.WriteLine("Invalid Credentials!\nTry Again");
                            Console.ReadKey();
                            MainMenu();
                        }

                        UserMenu(username);
                        break;
                    }
                case 2:
                    {
                        SignUp();
                        MainMenu();
                        break;
                    }

            }
        }

        public void UserMenu(string username)
        {
            Console.Clear();
            Console.WriteLine($"Logged in as  {username}");
            Console.WriteLine("User Menu : ");
            Console.WriteLine("1. Create a Trip Offer.");
            Console.WriteLine("2. Search for a Trip.");
            Console.WriteLine("3. See all offers made by you. ");
            Console.WriteLine("4. See Requests for your Offer.");
            Console.WriteLine("5. See Bookings");
            Console.WriteLine("6. Logout");
            Console.WriteLine("Enter your Choice : ");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (choice)
            {
                case 1:
                    CreateTripOffer(username);
                    break;

                case 2:
                    SearchTripOffers(username);
                    break;

                case 3:
                    {
                        ICollection<TripOffer> Trips = TripServices.ShowTripOffers(username);
                        if (Trips.Count == 0)
                        {
                            Console.WriteLine("NO TRIPS FOUND!");
                            Console.ReadKey();
                            UserMenu(username);
                        }

                        foreach (TripOffer Trip in Trips)
                        {
                            Console.WriteLine($"\n\n {Trip.TripOfferId} | Driver : { Trip.Username } | { Trip.Date } | { Trip.Time } | { Trip.Source } to { Trip.Destination } | { Trip.Distance }kms | { Trip.CarModel } { Trip.CarNumber } | Total Seats : { Trip.TotalSeats } | Seats Left : { Trip.SeatsLeft } | Total Cost : { Trip.TotalCost}");
                        }
                        Console.ReadKey();
                        UserMenu(username);
                        break;
                    }

                case 4:
                    ApproveTripRequests(username);
                    break;

                case 5:
                    ShowTripBooking(username);
                    break;
                case 6:
                    MainMenu();
                    break;


                default:
                    Console.WriteLine("Invalid Selection!");
                    UserMenu(username);
                    break;
            }
        }

        public void ShowTripBooking(string username)
        {
            ICollection<TripBooking> Trips = TripServices.ShowTripBookings(username);
            if (Trips.Count == 0)
            {
                Console.WriteLine("NO TRIPS FOUND!");
                Console.ReadKey();
                UserMenu(username);
            }

            foreach (var trip in Trips)
            {
                Console.WriteLine($"\n {trip.TripOfferId}  | Trip Creator : {trip.Username} | { trip.Date } | { trip.Time } | { trip.Source } to { trip.Destination } | { trip.Distance }kms | { trip.CostPerHead } INR | Joined by { trip.Passenger }");
            }

            Console.ReadKey();
            UserMenu(username);

        }

        public void ApproveTripRequests(string username)
        {
            ICollection<TripRequest> Trips = TripServices.ShowTripJoiningRequests(username);
            if (Trips.Count == 0)
            {
                Console.WriteLine("NO REQUESTS FOUND!");
                Console.ReadKey();
                UserMenu(username);
            }
            foreach (var trip in Trips)
            {
                Console.WriteLine($"\n {trip.RequestId} | Trip Creator : { trip.TripCreater } | for : { trip.TripOfferId } | Requested Received from : { trip.TripPassenger }");
            }
            Console.WriteLine("\nEnter the Request ID for the request you want to approve: ");
            string requestId = Console.ReadLine();
            TripServices.ApproveTripJoinRequest(requestId);
            Console.WriteLine("Request Approved!!");
            Console.ReadKey();
            UserMenu(username);
        }

        public void SearchTripOffers(string username)
        {
            string date;
            string source;
            string destination;
            Console.WriteLine("Enter Date (DD/MM/YYYY): ");
            date = Console.ReadLine();
            Console.WriteLine("Enter Source : ");
            source = Console.ReadLine();
            Console.WriteLine("Enter Destination : ");
            destination = Console.ReadLine();

            ICollection<TripOffer> Trips = TripServices.SearchTrip(date, source, destination);
            if (Trips.Count == 0)
            {
                Console.WriteLine("NO TRIPS FOUND!");
                Console.ReadKey();
                UserMenu(username);
            }

            foreach (TripOffer Trip in Trips)
            {
                Console.WriteLine($"\n\n { Trip.TripOfferId}  | Driver : {Trip.Username} | {Trip.Date } | { Trip.Time } | { Trip.Source } to { Trip.Destination } | { Trip.Distance }kms | { Trip.CarModel } { Trip.CarNumber } | Total Seats : { Trip.TotalSeats } | Seats Left : { Trip.SeatsLeft } | Cost Per Head : { Trip.CostPerHead}");
            }
            Console.ReadKey();

            Console.WriteLine("\nEnter the Trip ID for the trip you are interested in : ");
            string tripOfferId = Console.ReadLine();
            TripServices.JoinTripRequest(username, tripOfferId);
            Console.WriteLine("Request Created!!");
            Console.ReadKey();
            UserMenu(username);

        }

        public void SignUp()
        {
            Console.Clear();
            string username;
            string password;
            Console.WriteLine("Enter User Name : ");
            username = Console.ReadLine();


            if (UserServices.ValidateUserName(username) == false)
            {
                Console.WriteLine("Username Already Exists!!");
                Console.WriteLine("Try Again with a different username.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Enter Password : ");
            password = Console.ReadLine();

            UserServices.AddUser(username, password);
        }

        public void CreateTripOffer(string username)
        {
            string date;
            string time;
            string source;
            string destination;
            double distance;
            string carModel;
            string carNumber;
            int totalSeats;
            decimal totalCost;

            Console.WriteLine("Enter Date for the trip (DD/MM/YYYY)");
            date = Console.ReadLine();
            Console.WriteLine("Enter Time for the Trip (hh:mm)");
            time = Console.ReadLine();
            Console.WriteLine("Enter Source");
            source = Console.ReadLine();
            Console.WriteLine("Enter Destination");
            destination = Console.ReadLine();
            Console.WriteLine("Enter Distance in kms ");
            distance = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Car Model");
            carModel = Console.ReadLine();
            Console.WriteLine("Enter Car Number");
            carNumber = Console.ReadLine();
            Console.WriteLine("Enter Total Seats Available");
            totalSeats = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Total Estimated Cost");
            totalCost = Convert.ToDecimal(Console.ReadLine());

            TripServices.CreateTripOffer(date, time, source, destination, distance, carModel, carNumber, totalSeats, totalCost, username);
            Console.WriteLine("Trip Offer Created!");
            UserMenu(username);
        }
    }
}
