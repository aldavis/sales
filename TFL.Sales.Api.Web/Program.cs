using System;
using System.IO;
using System.Linq;
using System.Net;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Email;

namespace TFL.Sales.Api.Web
{
	public class Program
	{
		public static int Main(string[] args)
		{
            //known issue with net core 2.2 related to in-process hosting
            //https://github.com/aspnet/AspNetCore.Docs/blob/master/aspnetcore/host-and-deploy/aspnet-core-module/samples_snapshot/2.x/CurrentDirectoryHelpers.cs

            CurrentDirectoryHelpers.SetCurrentDirectory();

			var configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.AddEnvironmentVariables()
				.Build();


			var loggerConfig = new LoggerConfiguration()
				.ReadFrom.Configuration(configuration);

			var smtpConfig = configuration.GetSection("SMTP");
			if (smtpConfig.GetChildren().Any())
			{
				var emailConnectionInfo = new EmailConnectionInfo
				{
					FromEmail = smtpConfig["FromEmail"],
					ToEmail = smtpConfig["ToEmail"],
					MailServer = smtpConfig["MailServer"],
					NetworkCredentials = new NetworkCredential(smtpConfig["UserName"], smtpConfig["Password"]),
					Port = 587,
					EnableSsl = false,
					EmailSubject = smtpConfig["EmailSubject"]
				};

				loggerConfig.WriteTo.Email(emailConnectionInfo, "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{Exception}{NewLine}", LogEventLevel.Error);
			}

			Log.Logger = loggerConfig.CreateLogger();

			try
			{
				Log.Information("Starting web host");
				CreateWebHostBuilder(args).Build().Run();
				return 0;
			}
			catch (Exception ex)
			{
				Log.Fatal(ex, "Web Host terminated unexpectedly");
				return 1;
			}
			finally
			{
				Log.CloseAndFlush();
			}
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>()
				.ConfigureServices(services => services.AddAutofac());
	}
}
