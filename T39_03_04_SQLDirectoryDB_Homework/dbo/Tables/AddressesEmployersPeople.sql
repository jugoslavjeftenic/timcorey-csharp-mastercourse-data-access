CREATE TABLE [dbo].[AddressesEmployersPeople]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AddressId] INT NOT NULL, 
    [EmployerId] INT NOT NULL, 
    [PersonId] INT NOT NULL
)
