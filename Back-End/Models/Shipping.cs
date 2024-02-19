using System;
using System.Collections.Generic;

namespace Back_End.Models
{
    public class Shipping
    {
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime? ShippedDate { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
