using System.Reflection;
using Autofac;
using MediatR;
using MediatR.Pipeline;
using TFL.Sales.Application.Features.Products;
using TFL.Sales.Application.Infrastructure.PipelineBehaviors;
using TFL.Sales.Domain.ProductRoot;

namespace TFL.Sales.Application.Infrastructure
{
	public class AutofacModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();

			builder.RegisterAssemblyTypes(typeof(ApplicationSettings).GetTypeInfo().Assembly)
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(Product).GetTypeInfo().Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            var mediatrOpenTypes = new[]
			{
				typeof(IRequestHandler<,>),
				typeof(INotificationHandler<>),
			};


			foreach (var mediatrOpenType in mediatrOpenTypes)
			{
				builder
					.RegisterAssemblyTypes(typeof(GetActiveProductsHandler).GetTypeInfo().Assembly)
					.AsClosedTypesOf(mediatrOpenType)
					.AsImplementedInterfaces();
			}

			builder.RegisterGeneric(typeof(RequestPreProcessorBehavior<,>)).AsImplementedInterfaces();
			builder.RegisterGeneric(typeof(RequestPostProcessorBehavior<,>)).AsImplementedInterfaces();

			builder.RegisterGeneric(typeof(RequestValidationBehavior<,>)).As(typeof(IPipelineBehavior<,>));

			builder.Register<ServiceFactory>(ctx =>
			{
				var c = ctx.Resolve<IComponentContext>();
				return t => c.Resolve(t);
			});

		}
	}
}
