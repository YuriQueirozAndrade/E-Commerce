using E_Commerce_API.Application.Interfaces.DTOs;
using E_Commerce_API.Application.Interfaces;
using E_Commerce_API.Core.Entities;

namespace E_Commerce_API.Application.Services
{
    public class OrderBuilder : IOrderBuilder
    {
        public Shipping CreateShipping()
        {
            return new Shipping
            {
                Service = "TestDemoService",
                Cost = 100, 
                TrackingNumber = "TestTrackingNumber",
                ShippedDate = null
            };
        }
        public Payment CreatePayment(decimal totalPrice)
        {

            return new Payment
            {
                PaymentMethod = "TestDemoMethod",
                TransactionId = "TestDemoTransactionId",
                Amount = totalPrice,
                Status = "TestDemoStatus"
            };
        }
        public Order CreateOrder(decimal totalPrice, string UserID)
        {
            return new Order
            {
                TotalAmount = totalPrice,
                UserId = UserID,
                Status = "IsTestDemo"
            };
        }
    }
}