#nullable enable
using Back_End.Models.BaseModels;

namespace Back_End.Models
{
    public class Shipping : Base
    {
        public string Service { get; set; }
        public decimal Cost { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime? ShippedDate { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
