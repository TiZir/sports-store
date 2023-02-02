USE TikhonovTR
GO
----------------------------------------------------------------������ � ����������
CREATE FUNCTION ADCard (@IDAD INT)
RETURNS TABLE
AS
return(
		SELECT A.PlatformAD as '���������',A.NameOfAD as '��� ����������',
		A.DescriptionOfAD as '�������� ����������'
		FROM ADs as A
		WHERE A.IDADs=@IDAD
)
GO

----------------------------------------------------------------������ � ����������




-----------------------------------------------------------------������
CREATE FUNCTION UserCard (@IDUser INT)
RETURNS TABLE
AS
return(
		SELECT  U.IDUsers as '����� ������������',U.Surname as '�������',U.Firstname as '���',
		U.Lastname as '��������',U.Phone as '�������',U.Email as '�����'
		FROM Users as U
		WHERE U.IDUsers=@IDUser
)
GO


CREATE FUNCTION OrderCard (@IDOrder INT)
RETURNS TABLE
AS
return(
		SELECT O.IDOrders as '����� ������',O.IDCode as '�������',
		O.IDEmployee as '����� �������', O.Quantity as '����������',O.CostOfOrder as '���� ������',
		O.AddressOrder as '�����',O.OrderStatus as '������ ��������',O.DateOfOrder as '���� ������'
		FROM Orders as O
		WHERE O.IDOrders=@IDOrder
)
GO
-----------------------------------------------------------------������





-----------------------------------------------------------------�������
CREATE FUNCTION SupCard (@IDSup INT)
RETURNS TABLE
AS
return(
		SELECT S.IDCode as '�������',S.IDSupplies as '����� ��������',S.Quantity as '���������� �� ��������',
		S.CostOfSupply as '���� ��������',S.Timing as '���� ��������'
		FROM Supplies as S
		WHERE S.IDSupplies=@IDSup
)
GO
-----------------------------------------------------------------�������