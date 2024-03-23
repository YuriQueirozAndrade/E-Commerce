using Back_End.Data;
using Back_End.Interfaces;
using Back_End.Models;
using Back_End.Models.DTOs;
using Microsoft.EntityFrameworkCore;
namespace Back_End.Services
{
    public class ProductRepository :Repository<Product>,IProduct<Product>
    {
        private readonly DataBaseContext _dbContext;
        private readonly IResponseDTO<Product> _dtoprod;
        public ProductRepository(DataBaseContext dbContext, IResponseDTO<Product> dtoprod) : base (dbContext:dbContext, dto:dtoprod)
        {
            _dtoprod = dtoprod;
            _dbContext = dbContext;
        }
        public async Task<List<decimal>> GetByPriceListID(List<int> listID)
        {
            return await _dbContext.Products.Where(entity => listID.Contains(entity.Id)).Select(product => product.Price).ToListAsync();
        }
        public async Task<IEnumerable<IDTO<Product>>> GetAllProducts()
        {
            var list =  _dtoprod.ToDtoList(await _dbContext.Set<Product>().ToListAsync());
            return list; 
        }
    }
}