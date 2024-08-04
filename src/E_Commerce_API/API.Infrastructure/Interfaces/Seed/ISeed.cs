using E_Commerce_API.Infrastructure.Data;

namespace E_Commerce_API.Interfaces
{
  public interface ISeed
  {
    public void DataSeed(DataBaseContext dbContext);
  }
}