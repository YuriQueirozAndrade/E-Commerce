using Back_End.Models.BaseModels;

namespace Back_End.Models
{
    public class Payment : Base
    {
        public string PaymentMethod { get; set; }
        public string TransactionId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}

