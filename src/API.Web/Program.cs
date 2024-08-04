using E_Commerce_API.Core.Entities;
using E_Commerce_API.Infrastructure.Data;
using E_Commerce_API.Config.DependencyInjection;
using E_Commerce_API.Config.Identity;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataBaseContext>(options => options.UseLazyLoadingProxies().UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("E_Commerce_API")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentity<User, IdentityRole>(options => {options.SignIn.RequireConfirmedAccount = false; options.SignIn.RequireConfirmedPhoneNumber = false; options.SignIn.RequireConfirmedEmail =false;}).AddEntityFrameworkStores<DataBaseContext>();
builder.Services.AddIdentityOptions();
builder.Services.AddIdentityCookies();

builder.Services.AddAuthorizationBuilder().AddPolicyService();

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);;


builder.Services.AddRepositoryDI();
builder.Services.AddServiceDI();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.SeederData();
app.Run();
