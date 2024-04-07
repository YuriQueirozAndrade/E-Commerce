using E_Commerce_API.Infrastructure.Data;
using E_Commerce_API.Core.Entities;
using E_Commerce_API.Application.DTOs;
using E_Commerce_API.Application.Interfaces.DTOs;
using E_Commerce_API.Application.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
namespace E_Commerce_API.Infrastructure.Repository
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
            return _dtoprod.ToDtoList(await _dbContext.Set<Product>().ToListAsync());
        }
    }
}