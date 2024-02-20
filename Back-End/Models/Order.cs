using System;
using System.Collections.Generic;

namespace Back_End.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public int IdPayment { get; set;}
        public Payment Payment { get; set;}

        public int IdShipping { get; set;}
        public Shipping Shipping { get; set;}
    }
}

