﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using T42_02_01_EFConsoleUI.DataAccess;

#nullable disable

namespace T42_02_01_EFConsoleUI.Migrations
{
	[DbContext(typeof(ContactContext))]
	[Migration("20231125135142_CreateDatabase")]
	partial class CreateDatabase
	{
		/// <inheritdoc />
		protected override void BuildTargetModel(ModelBuilder modelBuilder)
		{
#pragma warning disable 612, 618
			modelBuilder
				.HasAnnotation("ProductVersion", "7.0.14")
				.HasAnnotation("Relational:MaxIdentifierLength", 128);

			SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

			modelBuilder.Entity("T42_02_01_EFConsoleUI.Models.Contact", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnType("int");

					SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

					b.Property<string>("FirstName")
						.IsRequired()
						.HasColumnType("nvarchar(max)");

					b.Property<string>("LastName")
						.IsRequired()
						.HasColumnType("nvarchar(max)");

					b.HasKey("Id");

					//b.ToTable("MyProperty");
					b.ToTable("Contacts");
				});

			modelBuilder.Entity("T42_02_01_EFConsoleUI.Models.Email", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnType("int");

					SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

					b.Property<int?>("ContactId")
						.HasColumnType("int");

					b.Property<string>("EmailAddress")
						.IsRequired()
						.HasColumnType("nvarchar(max)");

					b.HasKey("Id");

					b.HasIndex("ContactId");

					b.ToTable("EmailAddresses");
				});

			modelBuilder.Entity("T42_02_01_EFConsoleUI.Models.Phone", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnType("int");

					SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

					b.Property<int?>("ContactId")
						.HasColumnType("int");

					b.Property<string>("PhoneNumber")
						.IsRequired()
						.HasColumnType("nvarchar(max)");

					b.HasKey("Id");

					b.HasIndex("ContactId");

					b.ToTable("PhoneNumbers");
				});

			modelBuilder.Entity("T42_02_01_EFConsoleUI.Models.Email", b =>
				{
					b.HasOne("T42_02_01_EFConsoleUI.Models.Contact", null)
						.WithMany("EmailAddresses")
						.HasForeignKey("ContactId");
				});

			modelBuilder.Entity("T42_02_01_EFConsoleUI.Models.Phone", b =>
				{
					b.HasOne("T42_02_01_EFConsoleUI.Models.Contact", null)
						.WithMany("PhoneNumbers")
						.HasForeignKey("ContactId");
				});

			modelBuilder.Entity("T42_02_01_EFConsoleUI.Models.Contact", b =>
				{
					b.Navigation("EmailAddresses");

					b.Navigation("PhoneNumbers");
				});
#pragma warning restore 612, 618
		}
	}
}
