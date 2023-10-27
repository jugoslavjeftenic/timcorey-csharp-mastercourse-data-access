CREATE TABLE [dbo].[ContactEmailAddresses]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ContactId] INT NOT NULL, 
    [EmailAddressId] INT NOT NULL
)
