using Back_End.Data;
using Microsoft.EntityFrameworkCore;

namespace Back_End.Interfaces
{
  public interface ISeed
  {
    public void DataSeed(DataBaseContext dbContext);
  }
}