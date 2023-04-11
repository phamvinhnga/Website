﻿using Website.Biz.Managers;
using Website.Biz.Managers.Interfaces;
using Website.Biz.Services;
using Website.Entity.Repositories;
using Website.Entity.Repositories.Interfaces;

namespace Website.Api.Services.ServiceBuilders
{
    internal static class InjectionServiceBuilder
    {
        internal static void UseInjectionServiceBuilder(this IServiceCollection services, IConfiguration configuration)
        {
            #region Manager
            services.AddTransient<IAuthManager, AuthManager>();
            services.AddTransient<IUserManager, UserManager>();
            services.AddTransient<IPostManager, PostManager>();
            services.AddTransient<IFileManager, FileManager>();
            services.AddTransient<ISpecializedManager, SpecializedManager>();
            #endregion End Manager

            #region Repository
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<ISpecializedRepository, SpecializedRepository>();
            #endregion End Repository
        }
    }
}
