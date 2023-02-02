USE TikhonovTR
GO

CREATE TABLE Products(
Code int IDENTITY (2222,1) NOT NULL,
NameOfProduct nvarchar(150),
DescriptionOfProduct nvarchar(100),
Quantity int,
Demand float,
CostOfGive money,
CostOfGet money,
CONSTRAINT PK_VendorCode_Code PRIMARY KEY CLUSTERED (Code)
)
GO 