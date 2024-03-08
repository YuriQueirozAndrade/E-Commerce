
using Back_End.Interfaces;
using Back_End.Models;
namespace Back_End.Services
{
    public class PaymentService :IPaymentService<Payment> 
    {
        public Payment CreatePayment(decimal amount)
        { 
            return new Payment
            {
                PaymentMethod = "TestDemoMethod",
                TransactionId = "TestDemoTransactionId",
                Amount = amount,
                Status = "TestDemoStatus"
            };
        }
        public decimal CalculeteAmount(List<decimal> prices, List<int> quantity, decimal shipping)
        {
            decimal amount = 0;
            for (int i = 0; i < prices.Count; i++)
            {
               amount += prices[i] * quantity[i];
            }
            amount += shipping;
            return amount;
        }
    }
}