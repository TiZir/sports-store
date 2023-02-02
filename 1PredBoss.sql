USE TikhonovTR
GO

CREATE VIEW AdminStat
AS
SELECT P.Code AS 'Артикул', P.NameOfProduct AS 'Название товара', P.Demand AS 'Спрос', 
P.CostOfGive+P.Demand*0.7 AS 'Цена на продажу', P.CostOfGet AS 'Цена на закупку',
A.IDADs AS 'Номер рекламы', A.Growth AS 'Прирост с рекламы', A.CostOfAD AS 'Цена рекламы'
FROM Products as P left join ADs AS A on P.Code=A.IDCode
Group by P.Code, P.NameOfProduct, P.Demand, P.CostOfGive+P.Demand*0.7, P.CostOfGet, A.IDADs, A.Growth, A.CostOfAD
GO

CREATE VIEW AdminEmp
AS
SELECT E.IDEmployees as 'Номер сотрудника',E.Surname as 'Фамилия',E.Firstname as 'Имя',
E.Lastname as 'Отчество',E.Position as 'Должность',E.Salary as 'Зарплата',
E.JobStatus as 'Статус работы',E.BusyStatus as 'Статус занятости'
FROM Employees as E
Group by E.IDEmployees,E.Surname,E.Firstname,E.Lastname,E.Position,E.Salary,E.JobStatus,E.BusyStatus
GO

CREATE VIEW AminСatalog
AS
SELECT P.Code as 'Артикул', P.NameOfProduct as 'Название товара', P.DescriptionOfProduct as 'Описание товара', 
P.Quantity as 'Количество на складе', S.IDSupplies as 'Номер поставки', P.CostOfGet as 'Цена на закупку', 
P.Demand as 'Спрос', P.CostOfGive+P.Demand*0.7 as 'Цена на продажу'
FROM Products as P left join Supplies AS S on P.Code=S.IDCode
group by P.Code, P.NameOfProduct, P.DescriptionOfProduct, P.Quantity, S.IDSupplies,
P.CostOfGet, P.Demand, P.CostOfGive+P.Demand*0.7
GO

CREATE VIEW AdminUsers
AS
SELECT O.IDUser as 'Номер пользователя',O.IDOrders as 'Номер заказа'
FROM Orders as O
Group by O.IDUser,O.IDOrders
GO
