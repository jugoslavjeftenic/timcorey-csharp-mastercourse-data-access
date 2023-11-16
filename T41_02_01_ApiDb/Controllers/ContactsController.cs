using Microsoft.AspNetCore.Mvc;
using T40_02_01_DataAccessLibrary;
using T40_02_01_DataAccessLibrary.Models;

namespace T41_02_01_ApiDb.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactsController : ControllerBase
	{
		private readonly MongoDbDataAccess _db;
		private readonly string _tableName = "Contacts";
		private readonly IConfiguration _config;

		public ContactsController(IConfiguration config)
		{
			_config = config;
			_db = new("MongoContactsDB", _config.GetConnectionString("Default"));
		}

		[HttpGet]
		public List<ContactModel> GetAll()
		{
			return _db.LoadRecords<ContactModel>(_tableName);
		}

		[HttpPost]
		public void InsertRecord(ContactModel contact)
		{
			_db.UpsertRecord(_tableName, contact.Id, contact);
		}
	}
}
