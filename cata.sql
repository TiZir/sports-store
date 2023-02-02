USE TikhonovTR
GO

CREATE VIEW Сatal
AS
SELECT S.IDCode, P.Code as 'Артикул', P.NameOfProduct as 'Название товара', P.DescriptionOfProduct as 'Описание товара', 
P.Quantity as 'Количество на складе', S.IDSupplies as 'Номер поставки', P.CostOfGet as 'Цена на закупку', 
P.Demand as 'Спрос', P.CostOfGive+P.Demand*0.7 as 'Цена на продажу'
FROM Products as P left join Supplies AS S on P.Code=S.IDCode
group by  S.IDCode,P.Code, P.NameOfProduct, P.DescriptionOfProduct, P.Quantity, S.IDSupplies,
P.CostOfGet, P.Demand, P.CostOfGive+P.Demand*0.7
GO