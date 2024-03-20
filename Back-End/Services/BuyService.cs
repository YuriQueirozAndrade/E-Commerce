using Back_End.Data;
using Back_End.Interfaces;
using Back_End.Models;
using Back_End.Models.DTOs;
namespace Back_End.Services
{
    public class BuyService :IBuyService<Order> 
    {
        private readonly DataBaseContext _dbContext;
        private readonly IOrderDirector _orderDirector;
        private readonly IResponseDTO<Order> _responseDTO;
        public BuyService
        (DataBaseContext dbContext, IOrderDirector director,IResponseDTO<Order> responseDTO)
        {
            _dbContext = dbContext;
            _responseDTO = responseDTO;
            _orderDirector = director;
        }
        public async Task<IDTO<Order>> CreateOrder(Cart cart)
        {
            using  var transaction = _dbContext.Database.BeginTransactionAsync();

            try
            {
                var order = await _orderDirector.MakeOrder(cart);
                await _dbContext.Set<Order>().AddAsync(order);
                await _dbContext.SaveChangesAsync();
                await _dbContext.Database.CommitTransactionAsync();
                return _responseDTO.ToDto(order);
            }
            catch (Exception)
            {
                await _dbContext.Database.RollbackTransactionAsync();
                throw;
            }

        }
    }
}