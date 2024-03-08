using Back_End.Data;
using Back_End.Interfaces;
using Back_End.Models;
using Back_End.Models.InputModels;
using Microsoft.EntityFrameworkCore;
namespace Back_End.Services
{
    public class BuyService :IBuyService<Order,BuyInputModel> 
    {
        private readonly DataBaseContext _dbContext;
        private readonly IRepository<Order> _orderRepository;
        private readonly IOrderService<Order> _order;
        private readonly IOrderItemService<OrderItem,BuyInputModel> _orderItem;
        private readonly IShippingService<Shipping> _shipping;
        private readonly IPaymentService<Payment> _payment;
        private readonly IProduct<Product> _product;
        public BuyService
        (DataBaseContext dbContext,IOrderService<Order> order,IOrderItemService<OrderItem,BuyInputModel>
        orderItem,IShippingService<Shipping> shipping,IPaymentService<Payment> payment, IProduct<Product> product,IRepository<Order> orderRepository)
        {
            _dbContext = dbContext;
            _order = order;
            _orderItem = orderItem;
            _shipping = shipping;
            _payment = payment;
            _product = product;
            _orderRepository = orderRepository;
        }
        public async Task<Order> CreateOrder(List<BuyInputModel> model, string UserID)
        {
            using  var transaction = _dbContext.Database.BeginTransactionAsync();

            try
            {
                var currentShip = _shipping.CreateShipping();
                decimal amount = _payment.CalculeteAmount(await _product.GetByPriceListID(model.Select(mod => mod.ProductId).ToList()),model.Select(mod => mod.Quantity).ToList(),currentShip.Cost);
                var currentOrder = _order.CreateOrder(amount,UserID);
                currentOrder.OrderItems = _orderItem.CreateOrderItem(model);
                currentOrder.Shipping = currentShip;
                currentOrder.Payment = _payment.CreatePayment(currentOrder.TotalAmount);
                await _orderRepository.Create(currentOrder);
                await _dbContext.Database.CommitTransactionAsync();
                return currentOrder;
            }
            catch (System.Exception)
            {
                await _dbContext.Database.RollbackTransactionAsync();
                throw;
            }

        }
    }
}