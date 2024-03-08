using Back_End.Data;
using Back_End.Interfaces;
using Back_End.Models;
using Microsoft.EntityFrameworkCore;
namespace Back_End.Services
{
    public class ProductRepository :Repository<Product>,IProduct<Product>
    {
        private readonly DataBaseContext _dbContext;
        public ProductRepository(DataBaseContext dbContext) : base (dbContext:dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<decimal>> GetByPriceListID(List<int> listID)
        {
            return await _dbContext.Products.Where(entity => listID.Contains(entity.Id)).Select(product => product.Price).ToListAsync();
        }
    }
}