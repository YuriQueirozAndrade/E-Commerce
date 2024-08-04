namespace E_Commerce_API.Core.Entities
{
    public class Shipping : Base
    {
        public string Service { get; set; } = null!;
        public decimal Cost { get; set; }
        public string TrackingNumber { get; set; } = null!;
        public DateTime? ShippedDate { get; set; } = null!;

        public int OrderId { get; set; }
        public virtual Order Order { get; set; } = null!;
    }
}
