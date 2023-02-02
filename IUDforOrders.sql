use TikhonovTR
go

create procedure Input_Orders
	@IDCode int,
	@IDEmp int,
	@IDUser int,
	@Quant int,
	@Cost money,
	@Address nvarchar(60),
	@Date date,
	@OrderStatus bit
as
	set nocount on;
	set xact_abort on;
	insert into Orders
	values (
		@IDCode,
		@IDEmp,
		@IDUser,
		@Quant,
		@Cost,
		@Address,
		@Date,
		@OrderStatus 
	)
go

create procedure Update_Orders
	@IDOrder int,
	@Quant int,
	@Cost money,
	@Address nvarchar(60),
	@Date date
as
	set nocount on;
	set xact_abort on;
	update Orders
	set 
	Quantity=@Quant,
	CostOfOrder=@Cost,
	AddressOrder=@Address,
	DateOfOrder=@Date
	where IDOrders = @IDOrder
go

create procedure Update_Orders_Status
	@IDOrder int,
	@OrderStatus bit
as
	set nocount on;
	set xact_abort on;
	update Orders
	set 
	OrderStatus=@OrderStatus
	where IDOrders = @IDOrder
go

create procedure Update_Orders_Emp
	@IDOrder int,
	@IDEmployee int
as
	set nocount on;
	set xact_abort on;
	update Orders
	set 
	IDEmployee=@IDEmployee
	where IDOrders = @IDOrder
go

create procedure Delete__Orders
	@IDOrder int
as
	set nocount on;
	set xact_abort on;
	delete from Orders
	where IDOrders = @IDOrder
go