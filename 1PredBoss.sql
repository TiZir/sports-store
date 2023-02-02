USE TikhonovTR
GO

CREATE VIEW AdminStat
AS
SELECT P.Code AS '�������', P.NameOfProduct AS '�������� ������', P.Demand AS '�����', 
P.CostOfGive+P.Demand*0.7 AS '���� �� �������', P.CostOfGet AS '���� �� �������',
A.IDADs AS '����� �������', A.Growth AS '������� � �������', A.CostOfAD AS '���� �������'
FROM Products as P left join ADs AS A on P.Code=A.IDCode
Group by P.Code, P.NameOfProduct, P.Demand, P.CostOfGive+P.Demand*0.7, P.CostOfGet, A.IDADs, A.Growth, A.CostOfAD
GO

CREATE VIEW AdminEmp
AS
SELECT E.IDEmployees as '����� ����������',E.Surname as '�������',E.Firstname as '���',
E.Lastname as '��������',E.Position as '���������',E.Salary as '��������',
E.JobStatus as '������ ������',E.BusyStatus as '������ ���������'
FROM Employees as E
Group by E.IDEmployees,E.Surname,E.Firstname,E.Lastname,E.Position,E.Salary,E.JobStatus,E.BusyStatus
GO

CREATE VIEW Amin�atalog
AS
SELECT P.Code as '�������', P.NameOfProduct as '�������� ������', P.DescriptionOfProduct as '�������� ������', 
P.Quantity as '���������� �� ������', S.IDSupplies as '����� ��������', P.CostOfGet as '���� �� �������', 
P.Demand as '�����', P.CostOfGive+P.Demand*0.7 as '���� �� �������'
FROM Products as P left join Supplies AS S on P.Code=S.IDCode
group by P.Code, P.NameOfProduct, P.DescriptionOfProduct, P.Quantity, S.IDSupplies,
P.CostOfGet, P.Demand, P.CostOfGive+P.Demand*0.7
GO

CREATE VIEW AdminUsers
AS
SELECT O.IDUser as '����� ������������',O.IDOrders as '����� ������'
FROM Orders as O
Group by O.IDUser,O.IDOrders
GO
