namespace E_Commerce_API.Application.Interfaces.Services
{
  public interface IGetTotalValue
  {
      decimal CalculeteAmount(List<decimal> prices, List<int> quantity, decimal shipping);
  }
}
