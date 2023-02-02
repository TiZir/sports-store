USE TikhonovTR
GO

CREATE FUNCTION AboutDelivery (@StatusOrder bit)
RETURNS TABLE
AS
return(
		SELECT IDOrders, IDCode, IDUser, IDEmployee, Quantity, CostOfOrder, AddressOrder
		FROM Orders
		WHERE OrderStatus=@StatusOrder
)
GO