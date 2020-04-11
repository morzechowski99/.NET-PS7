DROP PROCEDURE sp_productList
GO
CREATE PROCEDURE sp_productList
AS
SELECT p.Id, name,price, longName 
FROM Product p, Category c
Where p.CategoryId = c.Id

