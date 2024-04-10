using E_Commerce_API.Core.Entities;

namespace E_Commerce_API.Application.Interfaces.Builder
{
    public interface IOrderBuilder
    {
        public Shipping CreateShipping();
        public Payment CreatePayment(decimal totalPrice);
        public Order CreateOrder(decimal totalPrice, string UserID);
    }
}