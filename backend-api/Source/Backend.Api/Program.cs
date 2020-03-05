using Amazon.Runtime;
using AWS.Logger;
using AWS.Logger.SeriLog;
using Backend.Domain.Core.Logs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Exceptions.Core;
using System;

namespace Backend.Presentation.Api
{
    public class Program
    {
        public static BasicAWSCredentials Credentials = new BasicAWSCredentials("AKIAI5J2QHI.?.Q7QTAZOKA", "LK8BCrftIY.?./J7a9ddff7Po2+m+ZSXwVhY+RLPcoH");

        public static void Main(string[] args)
        {
            AWSLoggerConfig configuration = new AWSLoggerConfig()
            {
                Credentials = Credentials,
                Region = "us-east-1",
                LogGroup = "hackaiti",
                DisableLogGroupCreation = true,
            };

            Log.Logger = new LoggerConfiguration()
#if DEBUG
                .MinimumLevel.Verbose()
#else
                .MinimumLevel.Information()
#endif
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .Enrich.With(new LogsEnricher())
                .Enrich.WithExceptionDetails(new DestructuringOptionsBuilder()
                    .WithDefaultDestructurers()
                    .WithRootName("data"))
#if DEBUG
                .WriteTo.Console(new LogsJsonFormatter())
#else
                .WriteTo.AWSSeriLog(configuration, null, new LogsJsonFormatter())
#endif
                .CreateLogger();

            try
            {
                Log.Information("Starting Web Host");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Web Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseSerilog();
    }
}
