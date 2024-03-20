#nullable enable
using Back_End.Models.BaseModels;

namespace Back_End.Models
{
    public class Product : Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public virtual List<OrderItem>? OrderItems { get; set; }
    }
}

