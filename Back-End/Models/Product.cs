using system;
using System.Collections.Generic;

namespace Back_End.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}

