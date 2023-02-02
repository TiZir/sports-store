USE TikhonovTR
GO

CREATE VIEW AD
AS
SELECT A.IDCode, P.Code as 'Артикул', P.NameOfProduct as 'Название товара', P.DescriptionOfProduct as 'Описание товара', 
P.Quantity as 'Количество на складе', P.Demand as 'Спрос', P.CostOfGive+P.Demand*0.7 as 'Цена на продажу',
A.IDADs as 'Номер рекламы', A.NameOfAD as 'Имя рекламщика', A.DescriptionOfAD as 'Описание рекламщика', 
A.Growth as 'Прирост с рекламы', A.CostOfAD as 'Цена рекламы', A.PlatformAD as 'Платформа'
FROM Products as P inner join ADs AS A on P.Code=A.IDCode
group by A.IDCode, P.Code, P.NameOfProduct, P.DescriptionOfProduct, P.Quantity, P.Demand,
P.CostOfGive+P.Demand*0.7, A.IDADs, A.NameOfAD, A.DescriptionOfAD,A.Growth,A.CostOfAD,A.PlatformAD
GO
