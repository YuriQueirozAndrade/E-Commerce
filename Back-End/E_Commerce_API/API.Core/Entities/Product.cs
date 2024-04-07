#nullable enable

namespace E_Commerce_API.Core.Entities
{
    public class Product : Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public virtual List<OrderItem>? OrderItems { get; set; }
    }
}

