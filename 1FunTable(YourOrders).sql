USE TikhonovTR
GO

CREATE FUNCTION YourOrders (@ID INT)
RETURNS TABLE
AS
return(
		SELECT O.IDEmployee, O.IDUser, O.IDOrders AS '����� ������', O.IDCode AS '�������', P.NameOfProduct AS '�������� ��������',
		P.DescriptionOfProduct AS '�������� ��������', E.Firstname AS '��� �������', O.Quantity AS '���������� �����������',
		O.CostOfOrder AS '���� ������', O.AddressOrder AS '����� ��������',O.OrderStatus AS '������ ��������'
		FROM (Orders AS O inner join Products as P on O.IDCode=P.Code) inner join Employees AS E on E.IDEmployees=O.IDEmployee
		WHERE O.IDUser=@ID
)
GO