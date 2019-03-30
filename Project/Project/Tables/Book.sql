CREATE TABLE [dbo].[Book]
(
	[ISBN] VARCHAR(17) NOT NULL PRIMARY KEY, 
    [Title] NVARCHAR(255) NOT NULL, 
    [YearPublished] INT NOT NULL, 
    [AuthorID] INT NOT NULL, 
    CONSTRAINT [FK_Book_Author] FOREIGN KEY ([AuthorID]) REFERENCES [Author]
)
