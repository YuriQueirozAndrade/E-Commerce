namespace Back_End.Interfaces
{
  public interface IProduct<TProduct> where TProduct : class
  {
      Task<List<decimal>> GetByPriceListID(List<int> listID);
      Task<IEnumerable<IDTO<TProduct>>> GetAllProducts();
  }
}