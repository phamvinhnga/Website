using Website.Biz.Services;
using Microsoft.Extensions.Configuration;
using Website.Biz.Managers;
using Website.Biz.Managers.Interfaces;
using Website.Entity.Repositories.Interfaces;
using Website.Entity.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Website.Api.Services.ServiceBuilders
{
    internal static class InjectionServiceBuilder
    {
        internal static void UseInjectionServiceBuilder(this IServiceCollection services, IConfiguration configuration)
        {
            #region Manager
            services.AddTransient<IAuthManager, AuthManager>();
            services.AddTransient<IPostManager, PostManager>();
            services.AddTransient<IFileManager, FileManager>();
            services.AddTransient<ILocationManager, LocationManager>();
            services.AddTransient<IShopManager, ShopManager>();
            #endregion End Manager

            #region Repository
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<IShopRepository, ShopRepository>();
            #endregion End Repository
        }
    }
}
