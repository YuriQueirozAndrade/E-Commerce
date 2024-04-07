using E_Commerce_API.Application.Interfaces;
using E_Commerce_API.Application.Interfaces.Services;
namespace E_Commerce_API.Services
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