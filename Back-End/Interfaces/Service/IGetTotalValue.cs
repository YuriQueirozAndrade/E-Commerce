namespace Back_End.Interfaces
{
  public interface IGetTotalValue
  {
      decimal CalculeteAmount(List<decimal> prices, List<int> quantity, decimal shipping);
  }
}
