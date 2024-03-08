using Back_End.Models.InputModels;
using Back_End.Interfaces;
using Back_End.Services;
using Back_End.Models;

namespace Back_End.Config.DependencyInjection
{
    public static class ServiceDI
    {
        public static IServiceCollection AddServiceDI(this IServiceCollection services)
        {
            services.AddScoped<IOrderService<Order>, OrderService>();
            services.AddScoped<IOrderItemService<OrderItem,BuyInputModel>, OrderItemService>();
            services.AddScoped<IPaymentService<Payment>, PaymentService>();
            services.AddScoped<IShippingService<Shipping>, ShippingService>();
            services.AddScoped<IBuyService<Order,BuyInputModel>, BuyService>();

            return services;
        }
    }
}