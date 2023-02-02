USE TikhonovTR
GO

CREATE VIEW StatTop
AS
SELECT A.IDCode, P.Code AS 'Артикул', P.NameOfProduct AS 'Название товара', P.Demand AS 'Спрос', 
P.CostOfGive+P.Demand*0.7 AS 'Цена на продажу', P.CostOfGet AS 'Цена на закупку',
A.IDADs AS 'Номер рекламы', A.Growth AS 'Прирост с рекламы', A.CostOfAD AS 'Цена рекламы'
FROM Products as P left join ADs AS A on P.Code=A.IDCode
Group by A.IDCode, P.Code, P.NameOfProduct, P.Demand, P.CostOfGive+P.Demand*0.7, P.CostOfGet, A.IDADs, A.Growth, A.CostOfAD
GO