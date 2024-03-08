#nullable enable
using Back_End.Models.BaseModels;

namespace Back_End.Models
{
    public class OrderItem : Base
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}

