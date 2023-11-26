using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using T42_02_01_EFConsoleUI.Models;

namespace T42_02_01_EFConsoleUI.DataAccess
{
	public class ContactContext : DbContext
	{
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Email> EmailAddresses { get; set; }
		public DbSet<Phone> PhoneNumbers { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json");
			var config = builder.Build();

			options.UseSqlServer(config.GetConnectionString("Default"));
		}
	}
}
