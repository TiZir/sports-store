USE TikhonovTR
GO

CREATE VIEW �atal
AS
SELECT S.IDCode, P.Code as '�������', P.NameOfProduct as '�������� ������', P.DescriptionOfProduct as '�������� ������', 
P.Quantity as '���������� �� ������', S.IDSupplies as '����� ��������', P.CostOfGet as '���� �� �������', 
P.Demand as '�����', P.CostOfGive+P.Demand*0.7 as '���� �� �������'
FROM Products as P left join Supplies AS S on P.Code=S.IDCode
group by  S.IDCode,P.Code, P.NameOfProduct, P.DescriptionOfProduct, P.Quantity, S.IDSupplies,
P.CostOfGet, P.Demand, P.CostOfGive+P.Demand*0.7
GO