using Back_End.Interfaces;
using Back_End.Models;
using Back_End.Models.InputModels;
namespace Back_End.Services
{
    public class OrderItemService :IOrderItemService<OrderItem,BuyInputModel> 
    {

        public List<OrderItem> CreateOrderItem(List<BuyInputModel> buyInputModels)
        {
            List<OrderItem> OrderItemList = new List<OrderItem>(buyInputModels.Count);
            for (int i = 0; i < buyInputModels.Count; i++)
            {
                OrderItem newItem = new OrderItem
                {
                    ProductId = buyInputModels[i].ProductId,
                    Quantity = buyInputModels[i].Quantity
                };
                OrderItemList.Insert(OrderItemList.Count, newItem);
            }
            return OrderItemList;
        }
    }
}