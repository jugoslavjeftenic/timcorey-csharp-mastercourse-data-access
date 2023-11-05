namespace T40_02_03_NoSQLDirectoryDALibrary_Homework.Models
{
	public class EmployerModel
	{
		private readonly string[] employers = new string[]
		{
			"ABC Corporation",
			"XYZ Company",
			"Smith & Associates",
			"Tech Innovations Inc.",
			"Global Solutions Group"
		};

		public Guid Id { get; set; } = Guid.NewGuid();
		public string Employer { get; set; }
		public AddressModel Address { get; set; }
		public List<PersonModel> People { get; set; } = new();

		public EmployerModel(string? employer = null, AddressModel? address = null)
		{
			Random random = new();

			Employer = employer ?? employers[random.Next(0, employers.Length)];

			Address = (address == null) ?
				Address = new AddressModel()
				: Address = new AddressModel()
				{
					StreetAddress = address.StreetAddress,
					City = address.City,
					Country = address.Country
				};
		}
	}
}
