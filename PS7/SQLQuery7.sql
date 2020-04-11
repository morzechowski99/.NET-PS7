DROP PROCEDURE sp_productChange
GO
CREATE PROCEDURE sp_productChange
@name NCHAR (50),
@price MONEY,
@CategoryID int,
@id int
AS
UPDATE PRODUCT 
SET NAME = @name, PRICE = @price, CategoryId = @CategoryID
WHERE ID = @id
GO