USE TikhonovTR
GO

CREATE VIEW ForUser 
AS
SELECT Code AS 'Артикул', NameOfProduct AS 'Название товара', DescriptionOfProduct AS 'Описание товара', Quantity AS 'Количество на складе',
CostOfGive+0.7*Demand AS 'Цена за штуку'
FROM dbo.Products
group by Code,NameOfProduct,DescriptionOfProduct,Quantity,CostOfGive+0.7*Demand
GO


--inner *
--right +