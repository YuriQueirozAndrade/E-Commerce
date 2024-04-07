using E_Commerce_API.Core.Entities;
using E_Commerce_API.Application.DTOs;
using E_Commerce_API.Infrastructure.Repository;
using E_Commerce_API.Application.Interfaces.DTOs;
using E_Commerce_API.Application.Interfaces.Repository;
using E_Commerce_API.Infrastructure.UnityOfWork;
using E_Commerce_API.Application.Interfaces;

namespace E_Commerce_API.Config.DependencyInjection
{
    public static class RepositoryDI
    {
        public static IServiceCollection AddRepositoryDI(this IServiceCollection services)
        {
            services.AddScoped<IAccount<User>, Account>();

            services.AddScoped<IResponseDTO<Address>, AddressDTO>();

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
            
            services.AddScoped<IUnityOfWork, UnityOfWork>();
            return services;
        }
    }
}