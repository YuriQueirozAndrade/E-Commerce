using Back_End.Interfaces;
using Back_End.Services;
using Back_End.Models;
using Back_End.Models.DTOs;

namespace Back_End.Config.DependencyInjection
{
    public static class ServiceDI
    {
        public static IServiceCollection AddServiceDI(this IServiceCollection services)
        {

            services.AddScoped<IOrderBuilder, OrderBuilder>();
            services.AddScoped<IGetTotalValue, GetTotalValue>();

            services.AddScoped<IOrderDirector, OrderDirector>();
            services.AddScoped<IBuyService<Order>, BuyService>();

            return services;
        }
    }
}