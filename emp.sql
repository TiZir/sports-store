USE TikhonovTR
GO

CREATE VIEW Emp
AS
SELECT E.IDEmployees as 'Номер сотрудника',E.Surname as 'Фамилия',E.Firstname as 'Имя',
E.Lastname as 'Отчество',E.Position as 'Должность',E.Salary as 'Зарплата',
E.JobStatus as 'Статус работы',E.BusyStatus as 'Статус занятости'
FROM Employees as E
Group by E.IDEmployees,E.Surname,E.Firstname,E.Lastname,E.Position,E.Salary,E.JobStatus,E.BusyStatus
GO