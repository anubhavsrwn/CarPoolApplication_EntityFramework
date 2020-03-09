using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarPoolApplication.Models
{
    public class TripRequest
    {
        [Key]
        public string RequestId { get; set; }
        public string TripCreater { get; set; }
        public string TripPassenger { get; set; }
        public string TripId { get; set; }


        public TripRequest() { }

        public TripRequest(string tripCreater, string tripPassenger, string tripId)
        {
            TripCreater = tripCreater;
            TripPassenger = tripPassenger;
            TripId = tripId;
            RequestId = "REQ" + DateTime.Now.ToString("mmss");
        }
    }
}
