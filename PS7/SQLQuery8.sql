DROP PROCEDURE sp_categoryDelete
GO
CREATE PROCEDURE sp_categoryDelete
@CategoryID int
AS
DELETE FROM Category WHERE Id = @CategoryID
GO