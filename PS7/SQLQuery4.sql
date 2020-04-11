DROP PROCEDURE sp_productById
GO
CREATE PROCEDURE sp_productById
@ProductID int
AS
SELECT p.Id, name,price, longName 
FROM Product p, Category c
Where p.CategoryId = c.Id
AND p.Id = @ProductID