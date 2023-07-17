using Microsoft.EntityFrameworkCore;
using SportsStore.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StoreDbContext>(opts => { opts.UseSqlServer(builder.Configuration["ConnectionStringS:SportsStoreConnection"]);});
builder.Services.AddScoped<IStoreRepository,EFStoreRepository>();
var app = builder.Build();
app.UseStaticFiles();
app.MapDefaultControllerRoute();
SeedData.EnsurePopulated(app);
app.Run();
// reset databse in command line in SportsStore folder enter this: dotnet ef database drop --force --context StoreDbContext