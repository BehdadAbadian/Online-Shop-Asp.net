using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Infrastructure.EFCore;
using ShopManagement.Infrastructure.EFCore.Repository;
using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Infrastructure.EFCore;
using DiscountManagement.Infrastructure.EFCore.Repository;
using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastructure.EFCore;
using InventoryManagement.Infrastructure.EFCore.Repository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddScoped<ProductCategoryRepository>();
//builder.Services.AddDbContext<ShopContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineShopDb")));


//builder.Services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();

var connectionString = builder.Configuration.GetConnectionString("OnlineShopDb");
ShopManagement.Configuration.ShopManagementBootstrapper.Configure(builder.Services, connectionString);
DiscountManagement.Configuration.DiscountManagementBootstrapper.Configure(builder.Services, connectionString);
InventoryManagement.Infrastructure.Configuration.InventoryManagementBootstrapper.Configure(builder.Services, connectionString);
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
