using E_Commerce_API.Services;
using E_Commerce_API.Core.Entities;
using E_Commerce_API.Application.Services;
using E_Commerce_API.Application.Interfaces;
using E_Commerce_API.Application.Interfaces.Services;

namespace E_Commerce_API.Config.DependencyInjection
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