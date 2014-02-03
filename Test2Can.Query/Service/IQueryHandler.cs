namespace Test2Can.Query.Service {
		public interface IQueryHandler<TQuery, TDto> where TQuery : IQuery<TDto> {
				TDto Handle(TQuery query);
		}

	public interface IQueryHandler<TDto> {
		TDto Handle(object query);
	}

	public abstract class QueryHandler<TQuery, TDto> : IQueryHandler<TDto>, IQueryHandler<TQuery, TDto>
		where TQuery : IQuery<TDto> {

		public abstract TDto Handle(TQuery query);

		TDto IQueryHandler<TDto>.Handle(object query) {
			return Handle((TQuery)query);
		}
	}
}
