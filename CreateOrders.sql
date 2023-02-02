USE TikhonovTR
GO

CREATE TABLE Orders(
IDOrders int IDENTITY (1,1) NOT NULL,
IDCode int NOT NULL,
IDEmployee int NOT NULL,
IDUser int NOT NULL,
Quantity int,
CostOfOrder money,
AddressOrder nvarchar(60),
DateOfOrder date,
OrderStatus bit,
CONSTRAINT PK_OrdersTable_IDOrders PRIMARY KEY CLUSTERED (IDOrders,IDCode),
CONSTRAINT FK_OrdersTable_IDCode foreign key (IDCode) references Products (Code) on delete cascade,
CONSTRAINT FK_OrdersTable_IDEmployee foreign key (IDEmployee) references Employees (IDEmployees) on delete cascade,
CONSTRAINT FK_OrdersTable_IDUser foreign key (IDUser) references Users (IDUsers) on delete cascade
)
GO 