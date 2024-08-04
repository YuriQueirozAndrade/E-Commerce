#nullable enable
namespace E_Commerce_API.Core.Entities
{
    public class Payment : Base
    {
        public string PaymentMethod { get; set; } = null!;
        public string TransactionId { get; set; } = null!;
        public decimal Amount { get; set; }
        public string Status { get; set; } = null!;

        public int OrderId { get; set; }
        public virtual Order Order { get; set; } = null!;
    }
}

