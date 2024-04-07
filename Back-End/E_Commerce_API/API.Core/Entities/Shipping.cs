#nullable enable

namespace E_Commerce_API.Core.Entities
{
    public class Shipping : Base
    {
        public string Service { get; set; }
        public decimal Cost { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime? ShippedDate { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
