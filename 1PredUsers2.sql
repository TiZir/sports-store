USE TikhonovTR
GO

CREATE VIEW ForUserDelivery
AS
SELECT E.IDEmployees 'Номер курьера', E.Firstname as 'Имя курьера' 
FROM Employees AS E
Where E.BusyStatus=0 and E.Position='Курьер'
group by E.IDEmployees,E.Firstname
GO
