namespace T40_02_03_NoSQLDirectoryDALibrary_Homework.Models
{
	public class PersonModel
	{
		private readonly string[] firstNames = new string[]
		{
			"John",
			"Mary",
			"Michael",
			"Jennifer",
			"William",
			"Elizabeth",
			"James",
			"Sarah",
			"David",
			"Amanda"
		};

		private readonly string[] lastNames = new string[]
		{
			"Smith",
			"Johnson",
			"Williams",
			"Jones",
			"Brown",
			"Davis",
			"Miller",
			"Wilson",
			"Moore",
			"Taylor",
		};

		public string FirstName { get; set; }
		public string LastName { get; set; }

		public PersonModel(string? firstName = null, string? lastName = null)
		{
			Random random = new();

			FirstName = (string.IsNullOrEmpty(firstName)) ?
				firstNames[random.Next(0, firstNames.Length)] : firstName;
			LastName = (string.IsNullOrEmpty(lastName)) ?
				lastNames[random.Next(0, lastNames.Length)] : lastName;
		}
	}
}
