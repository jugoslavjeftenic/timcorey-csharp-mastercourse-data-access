-- Read All --
SELECT [c].[Id], [c].[FirstName], [c].[LastName],
	[e].[Id], [e].[ContactId], [e].[EmailAddress],
	[p].[Id], [p].[ContactId], [p].[PhoneNumber]
FROM [Contacts] AS [c]
LEFT JOIN [EmailAddresses] AS [e] ON [c].[Id] = [e].[ContactId]
LEFT JOIN [PhoneNumbers] AS [p] ON [c].[Id] = [p].[ContactId]
ORDER BY [c].[Id], [e].[Id]

-- Change First Name --
exec sp_executesql N'SELECT TOP(1) [c].[Id], [c].[FirstName], [c].[LastName]
FROM [Contacts] AS [c]
WHERE [c].[Id] = @__id_0',N'@__id_0 int',@__id_0=1
go
exec sp_executesql N'SET IMPLICIT_TRANSACTIONS OFF;
SET NOCOUNT ON;
UPDATE [Contacts] SET [FirstName] = @p0
OUTPUT 1
WHERE [Id] = @p1;
',N'@p1 int,@p0 nvarchar(4000)',@p1=1,@p0=N'Timothy'
go

-- Remove Phone Number --
exec sp_executesql N'SELECT [t].[Id], [t].[FirstName], [t].[LastName], [p].[Id], [p].[ContactId], [p].[PhoneNumber]
FROM (
    SELECT TOP(1) [c].[Id], [c].[FirstName], [c].[LastName]
    FROM [Contacts] AS [c]
    WHERE [c].[Id] = @__id_0
) AS [t]
LEFT JOIN [PhoneNumbers] AS [p] ON [t].[Id] = [p].[ContactId]
ORDER BY [t].[Id]',N'@__id_0 int',@__id_0=1
go
exec sp_executesql N'SET IMPLICIT_TRANSACTIONS OFF;
SET NOCOUNT ON;
UPDATE [PhoneNumbers] SET [ContactId] = @p0
OUTPUT 1
WHERE [Id] = @p1;
',N'@p1 int,@p0 int',@p1=1,@p0=NULL
go
