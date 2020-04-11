DROP PROCEDURE sp_categoryById
GO
CREATE PROCEDURE sp_categoryById
@CategoryID int
AS
SELECT Id, shortName, longName
FROM Category 
Where Id = @CategoryID