USE TikhonovTR
GO

CREATE TABLE Employees(
IDEmployees int IDENTITY (1,1) NOT NULL,
Surname nvarchar(30),
Firstname nvarchar(30),
Lastname nvarchar(30),
Position nvarchar(30),
Salary money,
JobStatus nvarchar(30),
BusyStatus bit,
CONSTRAINT PK_EmployeesTable_IDEmployees PRIMARY KEY CLUSTERED (IDEmployees)
)
GO