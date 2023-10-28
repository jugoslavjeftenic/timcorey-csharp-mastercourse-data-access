CREATE TABLE [dbo].[PeopleEmployers]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PersonId] INT NOT NULL, 
    [EmployerId] INT NOT NULL, 
    [Position] NVARCHAR(50) NOT NULL
)
