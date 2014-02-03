using System;

using Castle.MicroKernel;

using Test2Can.Query.Service;

namespace Test2Can.Dependencies.Services {
		public class ContainerQueryService : IQueryService {
			private readonly IKernel _kernel;

			public ContainerQueryService(IKernel kernel) {
				_kernel = kernel;
			}

			public TDto Query<TDto>(IQuery<TDto> query) {
				var service = _kernel.Resolve(typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TDto)));
				var handler = service as IQueryHandler<TDto>;
				if (handler == null) {
						throw new ComponentNotFoundException(typeof(IQuery<TDto>), "Handle handler for qeury not found");
				}
				
				try {
					return handler.Handle(query);
				}
				catch (Exception) {
					throw;
				}
				finally {
					_kernel.ReleaseComponent(service);
				}
			}
		}
}
