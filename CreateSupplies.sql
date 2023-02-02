USE TikhonovTR
GO

CREATE TABLE Supplies(
IDSupplies int IDENTITY (1,1) NOT NULL,
IDCode int NOT NULL,
Quantity int,
CostOfSupply money,
Timing date,
DeliveryStatus nvarchar(15)
CONSTRAINT PK_SuppliesTable_IDSupplies PRIMARY KEY CLUSTERED (IDSupplies,IDCode),
CONSTRAINT FK_SuppliesTable_IDCode foreign key (IDCode) references Products (Code) on delete cascade
)
GO 