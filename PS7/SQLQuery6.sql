DROP PROCEDURE sp_productAdd
GO
CREATE PROCEDURE sp_productAdd
@name NCHAR (50),
@price MONEY,
@CategoryID int
AS
INSERT INTO Product (name,price,CategoryId) VALUES (@name,@price,@CategoryID)