use TikhonovTR
go

create trigger SumOrd on Orders
instead of insert
as
declare @QuantP int,@CostP money, @ChekBusy bit, @IDCod int, @IDEmp int, @IDUser int, @Quant int, @CostOrder money,
@Address nvarchar(60), @DateOrder date, @OrderStat bit
begin
	select @IDCod=IDCode, @IDEmp=IDEmployee, @IDUser=IDUser, @Quant=Quantity, @CostOrder=CostOfOrder,
	@Address=AddressOrder, @DateOrder=DateOfOrder, @OrderStat=OrderStatus 
	from inserted

	select @QuantP=P.Quantity
	from Products as P
	where @IDCod=P.Code

	select @CostP=UP.[Цена за штуку]
	from ForUser  as UP
	where @IDCod=UP.Артикул

	set @CostOrder=CONVERT(float, @Quant)* @CostP 
	set @DateOrder=GETDATE()

	select @ChekBusy=E.BusyStatus
	from Employees as E
	where @IDEmp=E.IDEmployees

	if(@QuantP>=@Quant)
		begin
			if(@ChekBusy=1)
				begin
					Raiserror('Этот курьер занят, выберите другого',16,0)
					rollback transaction
				end
			else begin
				update Products SET Products.Quantity=@QuantP-@Quant where Products.Code=@IDCod
				update Products SET Products.Demand=Products.Demand+1 where Products.Code=@IDCod
				update Employees SET Employees.BusyStatus=1 where Employees.IDEmployees=@IDEmp
				insert into Orders
				values(@IDCod, @IDEmp, @IDUser, @Quant, @CostOrder,@Address, @DateOrder, @OrderStat )
			end
		end
	else begin
		Raiserror('На складе нет такого количества. На складе %d штук товара',16,0,@QuantP)
		rollback transaction
	end
end
go

create trigger OrdStat on Orders
after update
as
declare @IDEmp int, @OrderStat bit
begin
	select @IDEmp=IDEmployee, @OrderStat=OrderStatus from inserted

			if (@OrderStat=1) 
				begin
					update Employees SET Employees.BusyStatus=0 where Employees.IDEmployees=@IDEmp
				end
			else
				rollback transaction
end
go
