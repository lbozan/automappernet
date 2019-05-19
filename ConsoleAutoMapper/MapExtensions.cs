using AutoMapper;

namespace ConsoleAutoMapper
{
	public static class MapExtensions
	{
		public static PersonViewModel ToModel(this PersonDataModel data)
		=> Mapper.Map<PersonDataModel, PersonViewModel>(data);

		public static PersonDataModel ToData(this PersonViewModel view)
		=> Mapper.Map<PersonViewModel, PersonDataModel>(view);

		public static T TJen<T, V>(this V ent)
		=> Mapper.Map<V, T>(ent);
	}
}
