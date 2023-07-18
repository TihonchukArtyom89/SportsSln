using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsStore.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StoreDbContext>(opts => { opts.UseSqlServer(builder.Configuration["ConnectionStrings:SportsStoreConnection"]); });
builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();
var app = builder.Build();
app.UseStaticFiles();
app.MapControllerRoute("catpage", "{category}/Page{productPage:int}", new { Controller = "Home", Action = "Index" });
app.MapControllerRoute("page", "Page{productPage:int}", new { Controller = "Home", Action = "Index", productPage = 1 });
app.MapControllerRoute("category", "{category}", new { Controller = "Home", Action = "Index", productPage = 1 });
app.MapControllerRoute("pagination", "Products/Page{productPage}", new { Controller = "Home", Action = "Index", productPage = 1 });
app.MapDefaultControllerRoute();
SeedData.EnsurePopulated(app);
app.Run();
// reset databse in command line in SportsStore folder enter this: dotnet ef database drop --force --context StoreDbContext