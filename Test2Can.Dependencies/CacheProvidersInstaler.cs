using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using Test2Can.Dependencies.Services;

namespace Test2Can.Dependencies {
		public class CacheProvidersInstaler : IWindsorInstaller
		{
			public void Install(IWindsorContainer container, IConfigurationStore store) {
				container.Register(
					Component.For<ICacheProvider, CacheProvider>(),
					Component.For<ICacheKeyBuilder, CacheKeyBuilder>().LifestyleTransient());
			}
		}
}
