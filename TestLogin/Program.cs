using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TestLogin.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("LoginDbContextConnection") ?? throw new InvalidOperationException("Connection string 'LoginDbContextConnection' not found.");

builder.Services.AddDbContext<LoginDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<TestLoginUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<LoginDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapRazorPages();
app.Run();
