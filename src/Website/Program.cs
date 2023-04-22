
using AutoMapper;
using ServiceStack;
using Website.Biz.AutoMapper;
using Website.Entity.Model;
using Website.Services.ServiceBuilders;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
builder.Services.AddOptions<DbContextConnectionSettingOptions>()
    .Bind(builder.Configuration
        .GetSection(DbContextConnectionSettingOptions.Position))
    .ValidateDataAnnotations();
builder.Services.AddOptions<FileUploadSettingOptions>()
    .Bind(builder.Configuration
        .GetSection(FileUploadSettingOptions.Position))
    .ValidateDataAnnotations();
builder.Services.AddOptions<JWTSettingOptions>()
    .Bind(builder.Configuration
        .GetSection(JWTSettingOptions.Position))
    .ValidateDataAnnotations();
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
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

});
app.Run();
