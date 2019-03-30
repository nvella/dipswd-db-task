CREATE TABLE [dbo].[BookCopy]
(
	[CopyCount] INT NOT NULL , 
    [ISBN] VARCHAR(17) NOT NULL, 
    [StudentID] VARCHAR(9) NULL, 
    PRIMARY KEY ([CopyCount], [ISBN]), 
    CONSTRAINT [FK_BookCopy_Book] FOREIGN KEY ([ISBN]) REFERENCES [Book], 
    CONSTRAINT [FK_BookCopy_Student] FOREIGN KEY ([StudentID]) REFERENCES [Student]
)
