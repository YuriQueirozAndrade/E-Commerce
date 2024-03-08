using Back_End.Interfaces;
using Back_End.Services;
using Back_End.Models;
using Back_End.Controllers;

namespace Back_End.Config.DependencyInjection
{
    public static class RepositoryDI
    {
        public static IServiceCollection AddRepositoryDI(this IServiceCollection services)
        {
            services.AddScoped<IAccount<User>, Account>();
            services.AddScoped<IRepository<Product>, Repository<Product>>();
            services.AddScoped<IRepository<Order>, Repository<Order>>();

            services.AddScoped<IUser<Address>, UserRepository<Address>>();
            
            services.AddScoped<IProduct<Product>, ProductRepository>();
            return services;
        }
    }
}