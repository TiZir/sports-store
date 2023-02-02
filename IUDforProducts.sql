use TikhonovTR
go

create procedure Input_Products
	@Name nvarchar(150),
	@Desc nvarchar(100),
	@Quant int,
	@Demand float,
	@Give money,
	@Get money
as
	set nocount on;
	set xact_abort on;
	insert into Products
	values (
	@Name,
	@Desc,
	@Quant,
	@Demand,
	@Give,
	@Get
	)
go

create procedure Update_Products
	@Code int,
	@Name nvarchar(150),
	@Desc nvarchar(100),
	@Quant int,
	@Give money,
	@Get money
as
	set nocount on;
	set xact_abort on;
	update Products
	set 
	NameOfProduct=@Name,
	DescriptionOfProduct=@Desc,
	Quantity=@Quant,
	CostOfGive=@Give,
	CostOfGet=@Get
	where Code= @Code
go

create procedure Update_Products_Demand
	@Code int,
	@Demand float
as
	set nocount on;
	set xact_abort on;
	update Products
	set 
	Demand=@Demand
	where Code = @Code
go


create procedure Delete__Products
	@Code int
as
	set nocount on;
	set xact_abort on;
	delete from Products
	where Code = @Code
go