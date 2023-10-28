CREATE TABLE [dbo].[EmployersAddresses]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [EmployerId] INT NOT NULL, 
    [AddressId] INT NOT NULL
)
