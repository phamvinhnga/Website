﻿using Serilog;

namespace Website.Api.Services.ServiceBuilders
{
    public static class SerilogServiceBuilder
    {
        public static void CreateBuilder(IConfiguration configuration, IWebHostEnvironment env)
        {
            string defaultConnection = configuration.GetSection("ConnectionString:DefaultConnection").Value;
            string server = configuration.GetSection("ConnectionString:Server").Value;
            string database = configuration.GetSection("ConnectionString:Database").Value;
            string userId = configuration.GetSection("ConnectionString:UserId").Value;
            string password = configuration.GetSection("ConnectionString:Password").Value;

            var connectionString = string.Format(defaultConnection,
                                              server,
                                              database,
                                              userId,
                                              password,
                                              database);

            var loggerConfiguration = new LoggerConfiguration();
            if (env.IsDevelopment() || env.IsStaging())
            {
                loggerConfiguration.MinimumLevel.Debug();
            }
            
            if(configuration.GetValue<bool>("SerilogConfig:Database", false))
            {
                loggerConfiguration.WriteTo.MySQL(connectionString: connectionString, tableName: "log");
            }

            if (configuration.GetValue<bool>("SerilogConfig:File", true))
            {
                loggerConfiguration.WriteTo.File("App_Data/logs/log-.txt", rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}");
            }

            Log.Logger = loggerConfiguration
                .WriteTo.Console()
                .CreateLogger();
        }
    }
}
