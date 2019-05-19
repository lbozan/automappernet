using AutoMapper;
using System;

namespace ConsoleAutoMapper
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("World Hello!");

			SetMappings();

			PersonDataModel data = new PersonDataModel()
			{
				Id = 1,
				FullName = "devlabs",
				Email = "dev@labs.com",
				Role = "developer",
				CreatedAt = DateTime.Now
			};

			PersonDataCloneModel clone = data.TJen<PersonDataCloneModel, PersonDataModel>();
			Console.WriteLine($"Clone :{clone}");

			Console.WriteLine($"Data :{data}");

			PersonViewModel view = data.ToModel();
			Console.WriteLine($"View :{view}");

			view.CreatedBy = 7;
			view.Email = "labs@dev.com";
			Console.WriteLine($"View Edit :{view}");
			Console.WriteLine($"Data control :{data}");

			data = view.ToData();
			Console.WriteLine($"Data edit :{data}");

			Console.ReadLine();
		}


		static void SetMappings()
		{
			Mapper.Initialize(c =>
			{
				c.CreateMap<PersonDataModel, PersonViewModel>()
				  .ForMember(v => v.CreatedBy, f => f.Ignore());

				c.CreateMap<PersonViewModel, PersonDataModel>()
				  .ForMember(v => v.Id, f => f.Ignore())
				  .ForMember(v => v.Role, f => f.Ignore())
				  .ForMember(v => v.CreatedAt, f => f.Ignore());

				c.CreateMap<PersonDataModel, PersonDataCloneModel>();
			});
		}
	}


	public class PersonDataModel
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public string Email { get; set; }
		public string Role { get; set; }
		public DateTime CreatedAt { get; set; }

		public override string ToString()
		=> $"Id:{Id}, FullName:{FullName}, Email:{Email}, Role:{Role}, CreatedAt:{CreatedAt}";
	}

	public class PersonDataCloneModel : PersonDataModel
	{ }

	public class PersonViewModel
	{
		public string FullName { get; set; }
		public string Email { get; set; }
		public string Role { get; set; }
		public int CreatedBy { get; set; }

		public override string ToString()
		=> $"FullName:{FullName}, Email:{Email}, Role:{Role}, CreatedBy:{CreatedBy}";
	}
}
