using Back_End.Interfaces;
namespace Back_End.Services
{
    public class GetTotalValue :IGetTotalValue
    {
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