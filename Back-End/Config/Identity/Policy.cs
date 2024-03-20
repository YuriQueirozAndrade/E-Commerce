
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Back_End.Config.Identity
{
    public static class Policy
    {
        public static AuthorizationBuilder AddPolicyService(this AuthorizationBuilder services)
        {
            services.AddPolicy("RequireAdministratorRole", policy => policy.RequireRole("Admin"));
            services.AddPolicy("RequireUserRole", policy => policy.RequireRole("User"));
            return services;
        }
    }
}