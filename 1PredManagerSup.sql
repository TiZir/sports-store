USE TikhonovTR
GO

CREATE VIEW ForManagerSup
AS
SELECT P.Code as '�������', P.NameOfProduct as '�������� ������', P.DescriptionOfProduct as '�������� ������', 
P.Quantity as '���������� �� ������', S.IDSupplies as '����� ��������', S.Quantity as '���������� �� ��������', 
S.CostOfSupply AS '���� ��������', S.DeliveryStatus as '������ ��������', P.CostOfGet as '���� �� �������', 
P.Demand as '�����', P.CostOfGive+P.Demand*0.7 as '���� �� �������'
FROM Products as P left join Supplies AS S on P.Code=S.IDCode
group by P.Code, P.NameOfProduct, P.DescriptionOfProduct, P.Quantity, S.IDSupplies,S.Quantity,
S.CostOfSupply, S.DeliveryStatus, P.CostOfGet, P.Demand, P.CostOfGive+P.Demand*0.7
GO

--inner *
--right +
