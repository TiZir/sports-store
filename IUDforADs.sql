USE TikhonovTR
GO

CREATE PROCEDURE Input_ADS
@IDCode int,
@Growth float,
@Cost money,
@Platform nvarchar(12),
@Name nvarchar(30),
@Desc nvarchar(30)
AS
SET NOCOUNT ON;
SET XACT_ABORT ON;
INSERT INTO ADs
VALUES(
	@IDCode,
	@Growth,
	@COST,
	@Platform, 
	@Name, 
	@Desc);
GO

CREATE PROCEDURE Update_ADS
@IDAds INT,
@Cost money,
@Platform nvarchar(12),
@Name nvarchar(30),
@Desc nvarchar(30)
AS
SET NOCOUNT ON;
SET XACT_ABORT ON;
UPDATE ADs
	SET CostOfAD = @Cost,
		PlatformAD = @Platform, 
		NameOfAD = @Name, 
		DescriptionOfAD = @Desc
	WHERE IDADs=@IDAds
GO

CREATE PROCEDURE Update_ADS_Growth
@IDAds INT,
@Growth float
AS
SET NOCOUNT ON;
SET XACT_ABORT ON;
UPDATE ADs
	SET Growth=@Growth
	WHERE IDADs=@IDAds
GO

CREATE PROCEDURE Delete_ADS
@IDAds INT
AS
SET NOCOUNT ON;
SET XACT_ABORT ON;
DELETE FROM ADs
	WHERE IDADs=@IDAds
GO