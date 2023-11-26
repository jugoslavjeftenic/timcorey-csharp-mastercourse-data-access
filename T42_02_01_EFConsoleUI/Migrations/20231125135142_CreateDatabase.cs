using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace T42_02_01_EFConsoleUI.Migrations
{
	/// <inheritdoc />
	public partial class CreateDatabase : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Contacts",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
					LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table =>
				{
					//table.PrimaryKey("PK_MyProperty", x => x.Id);
					table.PrimaryKey("PK_Contacts", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "EmailAddresses",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
					ContactId = table.Column<int>(type: "int", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_EmailAddresses", x => x.Id);
					table.ForeignKey(
						//name: "FK_EmailAddresses_MyProperty_ContactId",
						name: "FK_EmailAddresses_Contacts_ContactId",
						column: x => x.ContactId,
						//principalTable: "MyProperty",
						principalTable: "Contacts",
						principalColumn: "Id");
				});

			migrationBuilder.CreateTable(
				name: "PhoneNumbers",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
					ContactId = table.Column<int>(type: "int", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_PhoneNumbers", x => x.Id);
					table.ForeignKey(
						//name: "FK_PhoneNumbers_MyProperty_ContactId",
						name: "FK_PhoneNumbers_Contacts_ContactId",
						column: x => x.ContactId,
						//principalTable: "MyProperty",
						principalTable: "Contacts",
						principalColumn: "Id");
				});

			migrationBuilder.CreateIndex(
				name: "IX_EmailAddresses_ContactId",
				table: "EmailAddresses",
				column: "ContactId");

			migrationBuilder.CreateIndex(
				name: "IX_PhoneNumbers_ContactId",
				table: "PhoneNumbers",
				column: "ContactId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "EmailAddresses");

			migrationBuilder.DropTable(
				name: "PhoneNumbers");

			migrationBuilder.DropTable(
				name: "MyProperty");
		}
	}
}
