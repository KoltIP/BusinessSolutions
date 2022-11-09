using BusinessSolutions.MVC;
using BusinessSolutions.MVC.Configuration.AutoMapperConfiguration;
using BusinessSolutions.MVC.Configuration.DbConfiguration;
using BusinessSolutions.MVC.Configuration.VersionConfiguration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAppVersion();

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();

builder.AddAppDbOption();

builder.Services.AddAppAutoMapper();

builder.Services.AddAppServices();

var app = builder.Build();

//app.UseMiddleware<Middleware>();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();

app.UseStatusCodePages();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
