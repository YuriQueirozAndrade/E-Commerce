namespace Back_End.Interfaces
{
  public interface IPaymentService<TEntity> where TEntity : class
  {
      TEntity CreatePayment(decimal amount);
      decimal CalculeteAmount(List<decimal> prices, List<int> quantity, decimal shipping);
  }
}
