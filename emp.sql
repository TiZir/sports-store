USE TikhonovTR
GO

CREATE VIEW Emp
AS
SELECT E.IDEmployees as '����� ����������',E.Surname as '�������',E.Firstname as '���',
E.Lastname as '��������',E.Position as '���������',E.Salary as '��������',
E.JobStatus as '������ ������',E.BusyStatus as '������ ���������'
FROM Employees as E
Group by E.IDEmployees,E.Surname,E.Firstname,E.Lastname,E.Position,E.Salary,E.JobStatus,E.BusyStatus
GO