﻿using Website.Entity;
using Website.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Website.Api.Services.ServiceBuilders
{
    internal static class SqlServiceBuilder
    {
        internal static void UseSqlServiceBuilder(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>()
                .AddIdentity<User, Role>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
        }

        internal static void UseMigrationServiceBuilder(this IServiceCollection services, IConfiguration configuration)
        {
            using var serviceScope = services.BuildServiceProvider().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            Log.Debug("Run migration");
            context?.Database.Migrate();
        }
    }
}
