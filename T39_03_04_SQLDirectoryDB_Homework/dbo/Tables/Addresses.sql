﻿CREATE TABLE [dbo].[Addresses]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [StreetAddress] NVARCHAR(100) NOT NULL, 
    [City] NVARCHAR(50) NOT NULL, 
    [Country] NVARCHAR(50) NOT NULL
)
