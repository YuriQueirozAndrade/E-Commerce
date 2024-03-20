using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Back_End.Data;
using Back_End.Models;
using System.Text.Json.Serialization;
using Back_End.Config.DependencyInjection;
using Back_End.Config.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataBaseContext>(options => options.UseLazyLoadingProxies().UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentity<User, IdentityRole>(options => {options.SignIn.RequireConfirmedAccount = false; options.SignIn.RequireConfirmedPhoneNumber = false; options.SignIn.RequireConfirmedEmail =false;}).AddEntityFrameworkStores<DataBaseContext>();
builder.Services.AddIdentityOptions();
builder.Services.AddIdentityCookies();

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

builder.Services.AddAuthorizationBuilder().AddPolicyService();

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
app.Run();