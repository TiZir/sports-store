use TikhonovTR
go

create trigger SupSumm on Supplies
instead of insert
as
declare @CostGet money, @IDCode int, @Quant int, @Cost money, @Timing date, @DelStatus bit
begin
	select @IDCode=IDCode, @Quant=Quantity, @Cost=CostOfSupply, @Timing=Timing , @DelStatus=DeliveryStatus from inserted

	select @CostGet=P.CostOfGet
	from Products as P
	where P.Code=@IDCode

	set @Timing=GETDATE()

	Set @Cost=@CostGet*@Quant
	insert into Supplies
	values(@IDCode, @Quant, @Cost, @Timing , @DelStatus)
end
go

create trigger QuantProd on Supplies
after update
as
declare @QuantP int, @IDSup int, @IDCode int, @Quant int ,@DelStat bit
begin

	select @IDSup=IDSupplies, @IDCode=IDCode, @Quant=Quantity, @DelStat=DeliveryStatus from inserted
	select @QuantP=P.Quantity
	from Products as P
	where P.Code=@IDCode
	if (@DelStat=1) 
		begin
			update Products SET Products.Quantity=@QuantP+@Quant where Products.Code=@IDCode
			delete from Supplies where IDSupplies=@IDSup
		end
	else
		rollback transaction
end
go