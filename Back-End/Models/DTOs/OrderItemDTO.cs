#nullable enable
using Back_End.Interfaces;
namespace Back_End.Models.DTOs
{
    public class OrderItemDTO : IDTO<OrderItem>,IResponseDTO<OrderItem>
   {
        public int Quantity { get; set; }
        public int ProductId { get; set; }

        public void UpdateEntity(OrderItem orderItem)
        {
            orderItem.Quantity = Quantity;
            orderItem.ProductId = ProductId;
        }
        public OrderItem ToEntity()
        {
            return new OrderItem
            {
               Quantity = Quantity,
               ProductId = ProductId,
            };
        }
        public IDTO<OrderItem> ToDto(OrderItem entity)
        {
          return new OrderItemDTO
          {
               Quantity = entity.Quantity,
               ProductId = entity.ProductId,
          };
        }
        public List<IDTO<OrderItem>> ToDtoList(List<OrderItem> products)
        {
            List<IDTO<OrderItem>> OrderItemDTOList = new List<IDTO<OrderItem>>(products.Count);
            for (int i = 0; i < OrderItemDTOList .Count; i++)
            {
                IDTO<OrderItem> newItemDTO = ToDto(products[i]);
                OrderItemDTOList.Add(newItemDTO);
            }
            return OrderItemDTOList;
        }
 
   }
}