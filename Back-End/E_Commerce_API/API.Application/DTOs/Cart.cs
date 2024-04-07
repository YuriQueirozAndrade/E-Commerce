#nullable enable
using E_Commerce_API.Core.Entities;
using E_Commerce_API.Application.Interfaces.DTOs;
namespace E_Commerce_API.Application.DTOs
{
    public class Cart : ICart<OrderItem>
   {
        public string UserId { get; set; }
        public List<OrderItemDTO> ListProducts {get; set;}
        public List<OrderItem> ToOrderItemList()
        {
            List<OrderItem> OrderItemList = new List<OrderItem>(ListProducts.Count);
            for (int i = 0; i < OrderItemList.Count; i++)
            {
                OrderItem newItem = ListProducts[i].ToEntity();
                OrderItemList.Add(newItem);
            }
            return OrderItemList;
        }
        public List<int> ToProductIDList()
        {
            return ListProducts.Select(mod => mod.ProductId).ToList();
        }
        public List<int> ToProductQuantityList()
        {
            return ListProducts.Select(mod => mod.Quantity).ToList();
        }
   }
}