namespace T39_03_05_SQLDirectoryDALibrary_Homework.Models
{
	public class AddressModel
	{
		private readonly string[] streetAddresses = new string[]
		{
			"123 Elm Street",
			"456 Maple Avenue",
			"789 Oakwood Lane",
			"1010 Cedar Drive",
			"1313 Willow Way",
			"1616 Birch Court",
			"1818 Pine Road",
			"2121 Spruce Circle",
			"2424 Magnolia Place",
			"2727 Sycamore Lane"
		};

		private readonly string[] cities = new string[]
		{
			"New York",
			"Los Angeles",
			"Chicago",
			"Houston",
			"Miami"
		};

		private readonly string[] countries = new string[]
		{
			"United States",
			"Canada",
			"United Kingdom",
			"Australia",
			"Germany"
		};

		public string StreetAddress { get; set; }
		public string City { get; set; }
		public string Country { get; set; }

		public AddressModel(string? streetAddress = null, string? city = null, string? country = null)
		{
			Random random = new();

			StreetAddress = (string.IsNullOrEmpty(streetAddress)) ?
				streetAddresses[random.Next(0, streetAddresses.Length)] : streetAddress;
			City = (string.IsNullOrEmpty(city)) ?
				cities[random.Next(0, cities.Length)] : city;
			Country = (string.IsNullOrEmpty(country)) ?
				countries[random.Next(0, countries.Length)] : country;
		}
	}
}
