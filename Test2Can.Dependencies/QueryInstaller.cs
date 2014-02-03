using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using Test2Can.Dependencies.Services;
using Test2Can.EFDao.Entity;
using Test2Can.Query.Service;

namespace Test2Can.Dependencies {
		public class QueryInstaller : IWindsorInstaller {
			public void Install(IWindsorContainer container, IConfigurationStore store) {
				container.Register(
					Component.For<IQueryService, QueryServiceCacheDecorator>()
						.DependsOn(
								Dependency.OnComponent("underlying", "ContainerQueryService")
					)
					.LifestyleTransient(),
					Component.For<IQueryService, ContainerQueryService>()
						.Named("ContainerQueryService")
						.LifestyleTransient(),
					Classes.FromAssemblyNamed("Test2Can.EFDao")
						.BasedOn(typeof(IQueryHandler<,>))
						.Unless(type => type.IsAbstract || type.IsGenericType)
						.WithServiceAllInterfaces()
						.LifestyleTransient(),
					Component
						.For<NORTHWNDEntities>()
						.LifestyleTransient());
			}
		}
}
