USE TikhonovTR
GO

CREATE TABLE Users(
IDUsers int IDENTITY (1,1) NOT NULL,
Surname nvarchar(30),
Firstname nvarchar(30),
Lastname nvarchar(30),
Phone nvarchar(15),
Email nvarchar(30),
CONSTRAINT PK_UsersTable_IDUsers PRIMARY KEY CLUSTERED (IDUsers)
)
GO