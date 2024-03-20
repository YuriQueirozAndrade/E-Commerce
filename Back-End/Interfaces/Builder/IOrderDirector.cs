using Back_End.Models;
using Back_End.Models.DTOs;

namespace Back_End.Interfaces
{
    public interface IOrderDirector
    {
        public Task<Order> MakeOrder(Cart cart); 
    }
}