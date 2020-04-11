DROP PROCEDURE sp_categoryList
GO
CREATE PROCEDURE sp_categoryList
AS
SELECT Id, shortName, longName 
FROM Category 
