USE TikhonovTR
GO

CREATE VIEW ForUserDelivery
AS
SELECT E.IDEmployees '����� �������', E.Firstname as '��� �������' 
FROM Employees AS E
Where E.BusyStatus=0 and E.Position='������'
group by E.IDEmployees,E.Firstname
GO
