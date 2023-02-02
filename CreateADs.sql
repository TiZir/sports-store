USE TikhonovTR
GO

CREATE TABLE ADs(
IDADs int IDENTITY (1,1) NOT NULL,
IDCode int NOT NULL,
Growth float,
CostOfAD money,
PlatformAD nvarchar(12),
NameOfAD nvarchar(30),
DescriptionOfAD nvarchar(30),
CONSTRAINT PK_ADsTable_IDADs PRIMARY KEY CLUSTERED (IDADs,IDCode),
CONSTRAINT FK_ADsTable_IDCode foreign key (IDCode) references Products (Code) on delete cascade
)
GO 