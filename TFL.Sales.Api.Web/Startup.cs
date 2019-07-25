using Autofac;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using TFL.Infrastructure.WebApi.Error;
using TFL.Infrastructure.WebApi.Filters;
using TFL.Sales.Application.Features.Products;
using TFL.Sales.Application.Infrastructure;

namespace TFL.Sales.Api.Web
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<ApplicationSettings>(x => Configuration.GetSection("ApiConfig").Bind(x));

			services.AddHealthChecks();


			services
				.AddMvc(options => { options.Filters.Add(new RequestValidationFilter()); })
				.AddFluentValidation(x => { x.RegisterValidatorsFromAssemblyContaining<ActivateProductRequest>(); })
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			services.AddSwaggerGen(x => { x.SwaggerDoc("v1", new Info {Title = "TFL.Sales.API", Version = "v1"}); });
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();
			else
				app.UseHsts();

			app.UseMiddleware(typeof(ErrorHandlingMiddleware));

			//app.UseHttpsRedirection();
			app.UseHealthChecks("/health");
			app.UseMvc();

			app.UseSwagger();
			app.UseSwaggerUI(x =>
			{
				x.SwaggerEndpoint("/swagger/v1/swagger.json", "TFL.DocuSign.API V1");
				x.RoutePrefix = string.Empty;
			});
		}

		public void ConfigureContainer(ContainerBuilder builder)
		{
			builder.RegisterModule(new AutofacModule());

			var applicationSettings = new ApplicationSettings();
			Configuration.GetSection("ApplicationSettings").Bind(applicationSettings);

			builder.RegisterInstance(applicationSettings).As<ApplicationSettings>().SingleInstance();
		}
	}
}