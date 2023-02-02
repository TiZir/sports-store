USE TikhonovTR
GO

CREATE FUNCTION ÑourierJob (@IDEmp int)
RETURNS @tabl TABLE (IDUser int,Surname nvarchar(30), Firstname nvarchar(30), Phone nvarchar(15), IDOrders int, 
IDCode int, NameOfProduct nvarchar(150), Quantity int, CostOfOrder money, AddressOrder nvarchar(60), OrderStatus bit)
AS
BEGIN
	INSERT @tabl
	SELECT O.IDUser, U.Surname, U.Firstname, U.Phone, O.IDOrders, 
	O.IDCode, P.NameOfProduct, O.Quantity, O.CostOfOrder,
	O.AddressOrder , O.OrderStatus
	FROM (Orders AS O inner join Users AS U ON O.IDUser=U.IDUsers) inner join Products AS P ON O.IDCode=P.Code
	WHERE O.IDEmployee=@IDEmp
	RETURN
END
GO