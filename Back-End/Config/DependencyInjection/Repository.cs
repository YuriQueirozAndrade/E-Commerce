using Back_End.Interfaces;
using Back_End.Services;
using Back_End.Models;
using Back_End.Controllers;
using Back_End.Models.DTOs;

namespace Back_End.Config.DependencyInjection
{
    public static class RepositoryDI
    {
        public static IServiceCollection AddRepositoryDI(this IServiceCollection services)
        {
            services.AddScoped<IAccount<User>, Account>();

            services.AddScoped<IRepository<Product>, Repository<Product>>();
            services.AddScoped<IProduct<Product>, ProductRepository>();

            services.AddScoped<IRepository<Order>, Repository<Order>>();

            services.AddScoped<IResponseDTO<Address>, AddressDTO>();
            services.AddScoped<IResponseDTO<Order>, OrderDTO>();
            services.AddScoped<IResponseDTO<Product>, ProductDTO>();

            services.AddScoped<IRepository<Order>, Repository<Order>>();
            services.AddScoped<IUser<Order>, UserRepository<Order>>();

            services.AddScoped<IRepository<Address>, Repository<Address>>();
            services.AddScoped<IUser<Address>, UserRepository<Address>>();
            
            return services;
        }
    }
}