using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using MVC.Models;
using Login.Models;


var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
// Add services to the container.
// ==========================================
services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;               // Url viết chữ thường
    // options.LowercaseQueryStrings = true;    // Query trong Url viết chữ thường
});
services.AddOptions();
services.Configure<MailSetting>(builder.Configuration.GetSection("MailSetting"));   // Đọc connfig gửi Mail 
services.AddTransient<SendMailService>();                                           // Đăng kí dịch vụ gửi Mail
services.AddDbContext<BurgeloContext>(options =>
{
    string connectString = builder.Configuration.GetConnectionString("BurgeloContext");
    options.UseSqlServer(connectString);
});
services.AddSingleton<ProductService>();
services.AddRazorPages();
services.AddControllersWithViews();
services.AddIdentity<UserModel, IdentityRole>()
.AddEntityFrameworkStores<BurgeloContext>()
.AddDefaultTokenProviders();
// ============================================

var contentRootPath = builder.Environment.ContentRootPath; // Thiết lập root

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
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");


    endpoints.MapRazorPages();
});


app.Run();
