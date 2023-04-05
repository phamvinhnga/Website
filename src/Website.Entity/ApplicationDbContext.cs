﻿using Website.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using Microsoft.Extensions.Options;
using System.Configuration;

namespace Website.Entity
{
    public class DbContextConnectionOptions
    {
        public static string Position { get { return "ConnectionString"; } }
        public string DefaultConnection { get; set; }
        public string Server { get; set; }
        public string UserId { get; set; }
        public string Database { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string Version { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        protected readonly IConfiguration _configuration;
        protected readonly DbContextConnectionOptions _dbContextConnectionOptions;
        private readonly string _connectionString;


        public DbContextConnectionOptions positionOptions { get; private set; }

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IOptions<DbContextConnectionOptions> dbContextConnectionOptions,
            IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
            _dbContextConnectionOptions = dbContextConnectionOptions.Value;
            _connectionString = string.Format(_dbContextConnectionOptions.DefaultConnection,
                                           _dbContextConnectionOptions.Server,
                                           _dbContextConnectionOptions.Database,
                                           _dbContextConnectionOptions.UserId,
                                           _dbContextConnectionOptions.Password,
                                           _dbContextConnectionOptions.Database);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         
            if (!optionsBuilder.IsConfigured)
            {
                Log.Debug("Begin connecting to database");
                optionsBuilder.UseMySql(_connectionString, new MySqlServerVersion(new Version(_dbContextConnectionOptions.Version)),
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
