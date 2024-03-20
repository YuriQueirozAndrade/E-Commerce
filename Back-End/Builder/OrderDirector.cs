using Back_End.Interfaces;
using Back_End.Models;
using Back_End.Models.DTOs;

namespace Back_End.Services
{
    public class OrderDirector : IOrderDirector
    {
        public readonly IOrderBuilder _builder;
        public readonly IGetTotalValue _getValue;
        public readonly IProduct<Product> _productRepo;
        public OrderDirector(IOrderBuilder builder, IGetTotalValue getValue, IProduct<Product> productRepo)
        {
            _builder = builder;
            _getValue = getValue;
            _productRepo = productRepo;
        }
        public async Task<Order> MakeOrder(Cart cart)
        {
            Shipping currentShip = _builder.CreateShipping();
            decimal amount = _getValue.CalculeteAmount(await _productRepo.GetByPriceListID(cart.ToProductIDList()),cart.ToProductQuantityList(),currentShip.Cost);
            Payment currentPay = _builder.CreatePayment(amount);
            Order currentOrder = _builder.CreateOrder(amount,cart.UserId);
            currentOrder.Shipping = currentShip;
            currentOrder.OrderItems = cart.ToOrderItemList();
            currentOrder.Payment = currentPay;
            currentOrder.UserId = cart.UserId;
            return currentOrder;
        }
    }
}