USE TikhonovTR
GO

CREATE VIEW StatTop
AS
SELECT A.IDCode, P.Code AS '�������', P.NameOfProduct AS '�������� ������', P.Demand AS '�����', 
P.CostOfGive+P.Demand*0.7 AS '���� �� �������', P.CostOfGet AS '���� �� �������',
A.IDADs AS '����� �������', A.Growth AS '������� � �������', A.CostOfAD AS '���� �������'
FROM Products as P left join ADs AS A on P.Code=A.IDCode
Group by A.IDCode, P.Code, P.NameOfProduct, P.Demand, P.CostOfGive+P.Demand*0.7, P.CostOfGet, A.IDADs, A.Growth, A.CostOfAD
GO