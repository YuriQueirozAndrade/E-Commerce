#nullable enable
using E_Commerce_API.Application.Interfaces.DTOs;
using E_Commerce_API.Core.Entities;
namespace E_Commerce_API.Application.DTOs
{
    public class OrderDTO : IDTO<Order>,IResponseDTO<Order>
   {
        public string OrderStatus { get; set; }
        public decimal TotalAmount { get; set; }
        public List<IDTO<OrderItem>> OrderItems { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionId { get; set; }
        public string PaymentStatus { get; set; }
        public string ShippingService { get; set; }
        public decimal ShippingCost { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime? ShippedDate { get; set; }

        public void UpdateEntity(Order order)
        {
            order.Status = OrderStatus;
            order.TotalAmount = TotalAmount;
            order.OrderItems = ToOrderItemList();
            order.Payment.PaymentMethod = PaymentMethod;
            order.Payment.TransactionId = TransactionId;
            order.Payment.Status = PaymentStatus;
            order.Shipping.Service = ShippingService;
            order.Shipping.Cost = ShippingCost;
            order.Shipping.TrackingNumber = TrackingNumber;
            order.Shipping.ShippedDate = ShippedDate;
        }
        public Order ToEntity()
        {
            List<OrderItem> orderItems = ToOrderItemList();
            Shipping shipping = new Shipping{Service = ShippingService, Cost = ShippingCost, TrackingNumber = TrackingNumber, ShippedDate = ShippedDate};
            Payment payment = new Payment{PaymentMethod = PaymentMethod,TransactionId = TransactionId, Status = PaymentStatus};
            return new Order
            {
                Status = OrderStatus,
                TotalAmount = TotalAmount,
               OrderItems = orderItems,
                Payment = payment,
                Shipping = shipping
            };
        }
        public IDTO<Order> ToDto(Order entity)
        {
          return new OrderDTO
          {
            OrderStatus = entity.Status,
            TotalAmount = entity.TotalAmount,
            OrderItems = ToDtoItemList(entity.OrderItems),
            PaymentMethod = entity.Payment.PaymentMethod,
            TransactionId = entity.Payment.TransactionId,
            PaymentStatus = entity.Payment.Status,
            ShippingService = entity.Shipping.Service,
            ShippingCost = entity.Shipping.Cost,
            TrackingNumber = entity.Shipping.TrackingNumber,
            ShippedDate = entity.Shipping.ShippedDate
          };
        }
        private List<OrderItem> ToOrderItemList()
        {
            List<OrderItem> OrderItemList = new List<OrderItem>(OrderItems.Count);
            for (int i = 0; i < OrderItemList.Count; i++)
            {
                OrderItem newItem = OrderItems[i].ToEntity();
                OrderItemList.Add(newItem);
            }
            return OrderItemList;
        }
        private List<OrderItemDTO> ToOrderItemDTOList(List<OrderItem> orderItems)
        {
            List<OrderItemDTO> OrderItemDTOList = new List<OrderItemDTO>(orderItems.Count);
            for (int i = 0; i < OrderItemDTOList .Count; i++)
            {
                OrderItemDTO newItemDTO = new OrderItemDTO{ProductId = orderItems[i].ProductId, Quantity = orderItems[i].Quantity};
                OrderItemDTOList.Add(newItemDTO);
            }
            return OrderItemDTOList;
        }
        public List<IDTO<OrderItem>> ToDtoItemList(List<OrderItem> entities)
        {
            List<IDTO<OrderItem>> ad = new List<IDTO<OrderItem>>(entities.Count);
            for (int i = 0; i < entities.Count; i++)
            {
                OrderItemDTO newItemDTO = new OrderItemDTO{ProductId = entities[i].ProductId, Quantity = entities[i].Quantity};
                ad.Add(newItemDTO);
            }
            return ad;
        }
        public List<IDTO<Order>> ToDtoList(List<Order> entities)
        {
            List<IDTO<Order>> ad = new List<IDTO<Order>>(entities.Count);
            for (int i = 0; i < entities.Count; i++)
            {
                ad.Add(
                ToDto(entities[i])
                );
            }
            return ad;
        }
   }
}