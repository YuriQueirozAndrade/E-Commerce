using E_Commerce_API.Core.Entities;
using E_Commerce_API.Core.Interfaces;
using E_Commerce_API.Application.Interfaces.Repository;
using E_Commerce_API.Application.DTOs;
using E_Commerce_API.Application.Interfaces;
using E_Commerce_API.Application.Interfaces.Services;
using E_Commerce_API.Application.Interfaces.DTOs;

namespace E_Commerce_API.Services
{
    public class BuyService :IBuyService<Order> 
    {
        private IRepository<Order> _orderRepository;
        private IUnityOfWork _unityOfWork;
        private readonly IOrderDirector _orderDirector;
        private readonly IResponseDTO<Order> _responseDTO;
        public BuyService
        (IOrderDirector director,IResponseDTO<Order> responseDTO,IRepository<Order> repository,IUnityOfWork unityOfWork)
        {
            _orderRepository = repository;
            _unityOfWork = unityOfWork;
            _responseDTO = responseDTO;
            _orderDirector = director;
        }
        public async Task<IDTO<Order>> CreateOrder(Cart cart)
        {
            try
            {
                var order = await _orderDirector.MakeOrder(cart);
                await _orderRepository.Create(order);
                await _unityOfWork.Commit();
                return _responseDTO.ToDto(order);
            }
            catch (Exception)
            {
                await _unityOfWork.RollBack();
                throw;
            }

        }
    }
}