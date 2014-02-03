namespace Test2Can.Query.Service {
		public interface IQueryService {
			TDto Query<TDto>(IQuery<TDto> query);
		}
}
