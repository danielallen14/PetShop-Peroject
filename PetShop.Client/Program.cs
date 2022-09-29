using Microsoft.EntityFrameworkCore;
using PetShop.Client.Repositories;
using PetShop.Data.Contexts;
using PetShop.Data.Repositories;
using PetShop.Service;
using Microsoft.AspNetCore.Identity;
using PetShop.Client.Data;
using PetShop.Client.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PetShopClientContextConnection") ?? throw new InvalidOperationException("Connection string 'PetShopClientContextConnection' not found.");

builder.Services.AddDbContext<PetShopClientContext>(options =>
    options.UseSqlServer(connectionString));;

builder.Services.AddDefaultIdentity<PetShopClientUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<PetShopClientContext>();;

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<PetShopDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PetShopDataConnection")));

builder.Services.AddScoped<IAnimalsRepository,AnimalRepository>();
builder.Services.AddScoped<IAnimalService,AnimalService>();
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();       //*************//
builder.Services.AddScoped<ICommentRepository,CommentRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();       //*************//



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
