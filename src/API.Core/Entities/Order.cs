using E_Commerce_API.Core.Interfaces;

namespace E_Commerce_API.Core.Entities
{
    public class Order : Base,IUserProperties
    {
        public string Status { get; set; } = null!;
        public decimal TotalAmount { get; set; }

        public string UserId { get; set; } = null!;
        public virtual User User { get; set; } = null!;

        public virtual List<OrderItem> OrderItems { get; set; } = null!;

        public int IdPayment { get; set;}
        public virtual Payment Payment { get; set;} = null!;

        public int IdShipping { get; set;}
        public virtual Shipping Shipping { get; set;} = null!;
    }
}

