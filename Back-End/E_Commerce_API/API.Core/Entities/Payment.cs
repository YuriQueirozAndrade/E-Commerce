#nullable enable
namespace E_Commerce_API.Core.Entities
{
    public class Payment : Base
    {
        public string PaymentMethod { get; set; }
        public string TransactionId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}

