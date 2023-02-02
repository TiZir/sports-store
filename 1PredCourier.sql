USE TikhonovTR
GO

CREATE VIEW ForCourier 
AS
SELECT O.IDUser, U.Surname as '������� �������', U.Firstname as '��� �������', U.Phone as '����� ��������',
O.IDOrders as '����� ������',O.IDCode as '�������', P.NameOfProduct as '�������� ������',
O.Quantity as '����������', O.CostOfOrder as '���� ������', O.AddressOrder as '����� ��������',
O.OrderStatus AS '������ ��������'
FROM (Orders as O inner join  Products as P on O.IDCode=P.Code) inner join Users AS U on O.IDUser=U.IDUsers
GROUP BY O.IDUser, U.Surname, U.Firstname, U.Phone, O.IDOrders, O.IDCode, P.NameOfProduct, O.Quantity,
O.CostOfOrder, O.AddressOrder, O.OrderStatus
GO


--inner *
--right +