using Back_End.Models;

namespace Back_End.Interfaces
{
    public interface IOrderBuilder
    {
        public Shipping CreateShipping();
        public Payment CreatePayment(decimal totalPrice);
        public Order CreateOrder(decimal totalPrice, string UserID);
    }
}