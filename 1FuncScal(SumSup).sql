USE TikhonovTR
GO

CREATE FUNCTION SummSup (@COD int, @Quan int)
RETURNS money
AS
BEGIN
	DECLARE @SUMMA money
	SELECT @SUMMA=P.CostOfGet*@Quan
	FROM Products as P 
	WHERE P.Code=@COD
	RETURN @SUMMA
END;