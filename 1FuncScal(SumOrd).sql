USE TikhonovTR
GO

CREATE FUNCTION SummOrderForUser (@UID int)
RETURNS money
AS
BEGIN
	DECLARE @SUMMA money
	SELECT @SUMMA=SUM(O.CostOfOrder)
	FROM Orders AS O
	WHERE O.IDUser=@UID and O.OrderStatus=0
	RETURN @SUMMA
END;
