namespace E_Commerce_API.Core.Entities
{
    public class Product : Base
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }

        public virtual List<OrderItem>? OrderItems { get; set; }
    }
}

