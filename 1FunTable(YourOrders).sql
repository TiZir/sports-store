USE TikhonovTR
GO

CREATE FUNCTION YourOrders (@ID INT)
RETURNS TABLE
AS
return(
		SELECT O.IDEmployee, O.IDUser, O.IDOrders AS 'Номер заказа', O.IDCode AS 'Артикул', P.NameOfProduct AS 'Название продукта',
		P.DescriptionOfProduct AS 'Описание продукта', E.Firstname AS 'Имя курьера', O.Quantity AS 'Количество заказанного',
		O.CostOfOrder AS 'Цена заказа', O.AddressOrder AS 'Адрес доставки',O.OrderStatus AS 'Статус доставки'
		FROM (Orders AS O inner join Products as P on O.IDCode=P.Code) inner join Employees AS E on E.IDEmployees=O.IDEmployee
		WHERE O.IDUser=@ID
)
GO