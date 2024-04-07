#nullable enable
using E_Commerce_API.Core.Interfaces;

namespace E_Commerce_API.Core.Entities
{
    public class Order : Base,IUserProperties
    {
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }

        public virtual List<OrderItem> OrderItems { get; set; }

        public int IdPayment { get; set;}
        public virtual Payment Payment { get; set;}

        public int IdShipping { get; set;}
        public virtual Shipping Shipping { get; set;}
    }
}

