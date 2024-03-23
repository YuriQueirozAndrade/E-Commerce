using Back_End.Models;
using Microsoft.AspNetCore.Identity;

namespace Back_End.Data
{
  public static class Seeder
  {
    public static WebApplication SeederData(this WebApplication app)
    {
        string AdRoleId = Guid.NewGuid().ToString();
        string UserRoleId = Guid.NewGuid().ToString();
        IdentityRole AdminRole = new IdentityRole
        {
            Id = AdRoleId,
            Name = "Admin",
            NormalizedName = "Admin".ToUpper(),
             
        };

        IdentityRole UserRole = new IdentityRole
        {
            Id = UserRoleId,
            Name = "User",
            NormalizedName = "User".ToUpper()
        };

        var hasher = new PasswordHasher<User>();
        string AdminID = "f0a2eaa0-2bdc-4c30-8009-ffbe569c28cc";
        string AdminUserName = "Admin@email.com";
        User Admin = new User
        {
            Id = AdminID,
            FirstName = "Admin",
            LastName = "Admin",
            UserName = AdminUserName,
            Email = AdminUserName,
            NormalizedEmail = AdminUserName.ToUpper(), 
            NormalizedUserName = AdminUserName.ToUpper(), 
            PasswordHash = hasher.HashPassword(null, "Admin"),
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString()
        };

        IdentityUserRole<string> attachedAdminRole = new IdentityUserRole<string>
        {
            RoleId = AdRoleId,
            UserId = AdminID,
        };
        using (var scope = app.Services.CreateScope())
        {
            using var currentContext = scope.ServiceProvider.GetRequiredService<DataBaseContext>();
            try
            {
                using (var context = currentContext)
                {
                    context.Database.EnsureCreated();

                    var currentAdminRole = context.Roles.FirstOrDefault(b => b.Name == "Admin");
                    if (currentAdminRole  == null)
                    {
                        context.Roles.Add(AdminRole);
                    }

                    var currentUserRole = context.Roles.FirstOrDefault(b => b.Name == "User");
                    if (currentUserRole == null)
                    {
                        context.Roles.Add(UserRole);
                    }

                    var currentAdmine = context.Users.FirstOrDefault(b => b.Id == AdminID ); 
                    if (currentAdmine  == null)
                    {
                        context.Users.Add(Admin);
                        context.UserRoles.Add(attachedAdminRole);
                    }

                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return app;
        }
    }
    
  }
}
