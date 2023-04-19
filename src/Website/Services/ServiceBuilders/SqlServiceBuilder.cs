using Website.Entity;
using Website.Entity.Entities;

namespace Website.Services.ServiceBuilders
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
    }
}
