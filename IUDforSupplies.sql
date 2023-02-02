use TikhonovTR
go

create procedure Input_Supplies
	@IDCode int,
	@Quan int,
	@Cost money,
	@Time date,
	@Stat bit
as
	set nocount on;
	set xact_abort on;
	insert into Supplies
	values (
		@IDCode,
		@Quan,
		@Cost,
		@Time,
		@Stat
	)
go

create procedure Update_Supplies
	@IDSup int,
	@Quan int,
	@Cost money,
	@Time date
as
	set nocount on;
	set xact_abort on;
	update Supplies
	set 
		Quantity=@Quan,
		CostOfSupply=@Cost,
		Timing=@Time
	where IDSupplies = @IDSup
go

create procedure Update_Supplies_Status
	@IDSup int,
	@Stat bit
as
	set nocount on;
	set xact_abort on;
	update Supplies
	set 
	DeliveryStatus=@Stat
	where IDSupplies = @IDSup
go


create procedure Delete_Supplies
	@IDSup int
as
	set nocount on;
	set xact_abort on;
	delete from Supplies
	where IDSupplies = @IDSup
go