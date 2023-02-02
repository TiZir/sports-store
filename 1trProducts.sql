use TikhonovTR
go

create trigger EndSumm on Products
instead of insert
as
declare @Code int, @Name nvarchar(150), @Descrip nvarchar(100), 
@Quant int, @Demond float, @CGive money, @CGet money
begin
	select @Code=Code, @Name=NameOfProduct, @Descrip=DescriptionOfProduct, 
	@Quant=Quantity, @Demond=Demand, @CGive=CostOfGive, @CGet=CostOfGet from inserted

	Set @CGive=@CGive+600
	insert into Products
	values(@Name, @Descrip, @Quant, @Demond, @CGive, @CGet)
end
go

