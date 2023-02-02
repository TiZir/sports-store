USE TikhonovTR
GO
----------------------------------------------------------------Работа с продукцией
CREATE FUNCTION ADCard (@IDAD INT)
RETURNS TABLE
AS
return(
		SELECT A.PlatformAD as 'Платформа',A.NameOfAD as 'Имя рекламщика',
		A.DescriptionOfAD as 'Описание рекламщика'
		FROM ADs as A
		WHERE A.IDADs=@IDAD
)
GO

----------------------------------------------------------------Работа с продукцией




-----------------------------------------------------------------Клиент
CREATE FUNCTION UserCard (@IDUser INT)
RETURNS TABLE
AS
return(
		SELECT  U.IDUsers as 'Номер пользователя',U.Surname as 'Фамилия',U.Firstname as 'Имя',
		U.Lastname as 'Отчество',U.Phone as 'Телефон',U.Email as 'Почта'
		FROM Users as U
		WHERE U.IDUsers=@IDUser
)
GO


CREATE FUNCTION OrderCard (@IDOrder INT)
RETURNS TABLE
AS
return(
		SELECT O.IDOrders as 'Номер заказа',O.IDCode as 'Артикул',
		O.IDEmployee as 'Номер курьера', O.Quantity as 'Количество',O.CostOfOrder as 'Цена заказа',
		O.AddressOrder as 'Адрес',O.OrderStatus as 'Статус доставки',O.DateOfOrder as 'Дата заказа'
		FROM Orders as O
		WHERE O.IDOrders=@IDOrder
)
GO
-----------------------------------------------------------------Клиент





-----------------------------------------------------------------Каталог
CREATE FUNCTION SupCard (@IDSup INT)
RETURNS TABLE
AS
return(
		SELECT S.IDCode as 'Артикул',S.IDSupplies as 'Номер поставки',S.Quantity as 'Количество на поставку',
		S.CostOfSupply as 'Цена поставки',S.Timing as 'Дата поставки'
		FROM Supplies as S
		WHERE S.IDSupplies=@IDSup
)
GO
-----------------------------------------------------------------Каталог