/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

IF '$(LoadTestData)' = 'true'
BEGIN

-- Delete all existing data in database before deploying new data
DELETE BookCopy;
DELETE Student;
DELETE Book;
DELETE Author;

INSERT INTO Student (StudentID, FirstName, LastName, Email, Mobile) VALUES 
('s12345678', 'Fred',    'Flinstone', '12345678@student.swin.edu.au', '0400555111'),
('s23456789', 'Barney',  'Rubble',    '23456789@student.swin.edu.au', '0400555222'),
('s34567890', 'Bam-Bam', 'Rubble',    '34567890@student.swin.edu.au', '0400555333');

INSERT INTO Author (AuthorID, FirstName, LastName, TFN) VALUES
(32567, 'Edgar', 'Codd', '150111222'),
(76543, 'Vinton', 'Cerf', '150222333'),
(12345, 'Alan', 'Turing', '150333444');

INSERT INTO Book (ISBN, Title, YearPublished, AuthorID) VALUES 
('978-3-16-148410-0', 'Relationships with Databases, the ins and outs', 1970, 32567),
('978-3-16-148410-1', 'Normalisation, how to make a database geek fit in.', 1973, 32567),
('978-3-16-148410-2', 'TCP/IP, the protocol for the masses.', 1983, 76543),
('978-3-16-148410-3', 'The Man, the Bombe, and the Enigma', 1940, 12345);

-- One physical copy of every book
INSERT INTO BookCopy (ISBN, CopyCount, StudentID) VALUES
('978-3-16-148410-0', 1, null),
('978-3-16-148410-1', 1, null),
('978-3-16-148410-2', 1, null),
('978-3-16-148410-3', 1, null);

END;