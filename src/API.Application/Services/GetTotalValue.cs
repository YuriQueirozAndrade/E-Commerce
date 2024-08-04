using E_Commerce_API.Application.Interfaces.Services;

namespace E_Commerce_API.Application.Services
{
    public class GetTotalValue :IGetTotalValue
    {
        public decimal CalculeteAmount (List<decimal> prices, List<int> quantity, decimal shipping)
        {
            if (prices == null || quantity == null || prices.Count != quantity.Count)
            {
                throw new ArgumentException("Prices and quantity lists must be of equal length and not null.");
            }

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