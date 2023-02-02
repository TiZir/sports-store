USE TikhonovTR
GO

CREATE VIEW ForCourier 
AS
SELECT O.IDUser, U.Surname as 'Фамилия клиента', U.Firstname as 'Имя клиента', U.Phone as 'Номер телефона',
O.IDOrders as 'Номер заказа',O.IDCode as 'Артикул', P.NameOfProduct as 'Название товара',
O.Quantity as 'Количество', O.CostOfOrder as 'Цена заказа', O.AddressOrder as 'Адрес доставки',
O.OrderStatus AS 'Статус доставки'
FROM (Orders as O inner join  Products as P on O.IDCode=P.Code) inner join Users AS U on O.IDUser=U.IDUsers
GROUP BY O.IDUser, U.Surname, U.Firstname, U.Phone, O.IDOrders, O.IDCode, P.NameOfProduct, O.Quantity,
O.CostOfOrder, O.AddressOrder, O.OrderStatus
GO


--inner *
--right +