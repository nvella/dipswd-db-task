﻿CREATE TABLE [dbo].[Student]
(
	[StudentID] VARCHAR(9) NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(255) NOT NULL, 
    [LastName] NVARCHAR(255) NOT NULL, 
    [Email] NVARCHAR(255) NOT NULL, 
    [Mobile] VARCHAR(255) NOT NULL
)
