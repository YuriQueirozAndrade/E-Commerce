#nullable enable
using E_Commerce_API.Application.Interfaces.DTOs;
using E_Commerce_API.Core.Entities;

namespace E_Commerce_API.Application.DTOs
{
    public class Cart : ICart<OrderItem>
   {
        public string UserId { get; set; } = null!;
        public List<OrderItemDTO> ListProducts {get; set;} = null!;

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
        public List<int> ToProductIDList() => ListProducts.Select(mod => mod.ProductId).ToList();
        public List<int> ToProductQuantityList() => ListProducts.Select(mod => mod.Quantity).ToList();
   }
}
