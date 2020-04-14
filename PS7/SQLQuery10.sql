DROP PROCEDURE sp_CategoryAdd
GO
CREATE PROCEDURE sp_CategoryAdd
@shortname NCHAR (20),
@longname NCHAR(100)
AS
INSERT INTO Category(shortname,longname) VALUES (@shortname,@longname)