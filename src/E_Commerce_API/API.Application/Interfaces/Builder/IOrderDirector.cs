using E_Commerce_API.Core.Entities;
using E_Commerce_API.Application.DTOs;

namespace E_Commerce_API.Application.Interfaces.Builder
{
    public interface IOrderDirector
    {
        public Task<Order> MakeOrder(Cart cart); 
    }
}