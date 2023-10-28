namespace T39_03_05_SQLDirectoryDALibrary_Homework.Models
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

		public string Employer { get; set; }

		public EmployerModel(string? employer = null)
		{
			Random random = new();

			Employer = (string.IsNullOrEmpty(employer)) ?
				employers[random.Next(0, employers.Length)] : employer;
		}
	}
}
