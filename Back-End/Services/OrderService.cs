using Back_End.Interfaces;
using Back_End.Models;
namespace Back_End.Services
{
    public class OrderService :IOrderService<Order> 
    {

        public Order CreateOrder(decimal amount, string UserID)
        {
            return new Order
            {
                TotalAmount = amount,
                UserId = UserID,
                Status = "IsTestDemo"
            };
        }
    }
}