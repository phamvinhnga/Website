
using AutoMapper;
using Website.Api.Services.ServiceBuilders;
using Website.Biz.AutoMapper;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
builder.Services.AddControllersWithViews();
builder.Services.UseSqlServiceBuilder(configuration);
builder.Services.UseInjectionServiceBuilder(configuration);
builder.Services.UseAuthServiceBuilder(configuration);
var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MappingProfile());
});

builder.Services.AddSingleton(config.CreateMapper());
var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
