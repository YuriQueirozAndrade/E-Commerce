using E_Commerce_API.Core.Entities;
using E_Commerce_API.Application.Interfaces.DTOs;
using E_Commerce_API.Application.DTOs;

namespace E_Commerce_API.Application.Interfaces
{
    public interface IOrderBuilder
    {
        public Shipping CreateShipping();
        public Payment CreatePayment(decimal totalPrice);
        public Order CreateOrder(decimal totalPrice, string UserID);
    }
}