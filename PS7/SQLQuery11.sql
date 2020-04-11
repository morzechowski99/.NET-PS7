DROP PROCEDURE sp_categoryEdit
GO
CREATE PROCEDURE sp_categoryEdit
@shortname NCHAR (20),
@longname NCHAR(100),
@id int
AS
UPDATE Category 
SET shortName = @shortname, longName = @longname
WHERE ID = @id
GO