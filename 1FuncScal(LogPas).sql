USE TikhonovTR
GO

CREATE FUNCTION LogPas (@Log nvarchar(30), @Pas int)
RETURNS bit
AS
BEGIN
	DECLARE @Check bit, @Email nvarchar(30), @IDUsers int
	SELECT @Email=U.Email
	FROM Users AS U
	WHERE U.IDUsers=@Pas
	IF(@Email=@Log) SET @Check=1
	ELSE SET @Check=0
	RETURN @Check
END;