USE TikhonovTR
GO

CREATE VIEW ForUser 
AS
SELECT Code AS '�������', NameOfProduct AS '�������� ������', DescriptionOfProduct AS '�������� ������', Quantity AS '���������� �� ������',
CostOfGive+0.7*Demand AS '���� �� �����'
FROM dbo.Products
group by Code,NameOfProduct,DescriptionOfProduct,Quantity,CostOfGive+0.7*Demand
GO


--inner *
--right +