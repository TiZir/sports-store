USE TikhonovTR
GO

CREATE VIEW ForManagerSup
AS
SELECT P.Code as 'Артикул', P.NameOfProduct as 'Название товара', P.DescriptionOfProduct as 'Описание товара', 
P.Quantity as 'Количество на складе', S.IDSupplies as 'Номер поставки', S.Quantity as 'Количество на поставку', 
S.CostOfSupply AS 'Цена поставки', S.DeliveryStatus as 'Статус поставки', P.CostOfGet as 'Цена на закупку', 
P.Demand as 'Спрос', P.CostOfGive+P.Demand*0.7 as 'Цена на продажу'
FROM Products as P left join Supplies AS S on P.Code=S.IDCode
group by P.Code, P.NameOfProduct, P.DescriptionOfProduct, P.Quantity, S.IDSupplies,S.Quantity,
S.CostOfSupply, S.DeliveryStatus, P.CostOfGet, P.Demand, P.CostOfGive+P.Demand*0.7
GO

--inner *
--right +
