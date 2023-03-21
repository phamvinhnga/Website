﻿using Website.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Website.Entity
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        protected readonly IConfiguration _configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string defaultConnection = _configuration.GetSection("ConnectionString:DefaultConnection").Value;
            string server = _configuration.GetSection("ConnectionString:Server").Value;
            string database = _configuration.GetSection("ConnectionString:Database").Value;
            string UserId = _configuration.GetSection("ConnectionString:UserId").Value;
            string password = _configuration.GetSection("ConnectionString:Password").Value;
            string port = _configuration.GetSection("ConnectionString:Port").Value;
            string version = _configuration.GetSection("ConnectionString:Version").Value;

            var connectionString = string.Format(defaultConnection,
                                              server,
                                              database,
                                              UserId,
                                              password,
                                              database);
            if (!optionsBuilder.IsConfigured)
            {
                Log.Debug("Begin connecting to database");
                optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(version)),
                    options => options.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null
                    )
                );
            }
            else
            {
                Log.Debug("Configured accsess to the database");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(
                new User { 
                    Id = 1, 
                    Name = "Admin",
                    Email = "Admin@gmail.com", 
                    Surname = "ADMIN", 
                    UserName = "Admin",
                    NormalizedUserName = "ADMIN",
                    NormalizedEmail = "Admin@gmail.com".ToUpper(),
                    PasswordHash = "AQAAAAEAACcQAAAAEFOoRzBpqXb8F0WviERxaxTASMpJTaTKwArF5PY8t1CP2R+9Wbxhkg8cAxH7iC1moA==", 
                    ConcurrencyStamp = "418f2935-171e-4f02-90b4-93a8746f4bf6",
                    SecurityStamp = "MI2WNXFQ63DAE4BCNM5YLJKU2MSFWIVQ",
                    ExtentionId = new Guid("2a17f888-1e93-4334-9189-d81c3aac9c45")
                }
            );
            builder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = "96dbb24d-4654-4ffc-ab7a-0d5468aae9df" },
                new Role { Id = 2, Name = "Staff", NormalizedName = "STAFF", ConcurrencyStamp = "59320394-0be6-4dba-8e5c-ee1068054d9c" }
            );
            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { UserId = 1, RoleId = 1 }
            );
            base.OnModelCreating(builder);
        }

        //public DbSet<Category> Category { get;set; }
        //public DbSet<WebSetting> WebSetting { get;set; }
        public DbSet<Post> Post { get;set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Shop> Shop { get; set; }
        public DbSet<CategoryFood> CategoryFood { get; set; }
    }
}
