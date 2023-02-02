USE TikhonovTR
GO

CREATE VIEW AD
AS
SELECT A.IDCode, P.Code as '�������', P.NameOfProduct as '�������� ������', P.DescriptionOfProduct as '�������� ������', 
P.Quantity as '���������� �� ������', P.Demand as '�����', P.CostOfGive+P.Demand*0.7 as '���� �� �������',
A.IDADs as '����� �������', A.NameOfAD as '��� ����������', A.DescriptionOfAD as '�������� ����������', 
A.Growth as '������� � �������', A.CostOfAD as '���� �������', A.PlatformAD as '���������'
FROM Products as P inner join ADs AS A on P.Code=A.IDCode
group by A.IDCode, P.Code, P.NameOfProduct, P.DescriptionOfProduct, P.Quantity, P.Demand,
P.CostOfGive+P.Demand*0.7, A.IDADs, A.NameOfAD, A.DescriptionOfAD,A.Growth,A.CostOfAD,A.PlatformAD
GO
