use TikhonovTR
go

create trigger CheckNameAndPhone on Users
instead of insert
as
declare @Sur nvarchar(30), @First nvarchar(30), @Last nvarchar(30), @Phone nvarchar(15), @Email nvarchar(30)
begin
	select @Sur=dbo.UpperW(Surname), @First=dbo.UpperW(Firstname) , @Last=dbo.UpperW(Lastname) , 
	@Phone=Phone , @Email=Email  from inserted

	if(dbo.PhoneN(@Phone)=1)
		begin
			insert into Users
			values(@Sur, @First, @Last , @Phone , @Email)
		end
	else
		begin	
			Raiserror('Неверный формат телефон. Пример: 89778524576',16,0)
			rollback transaction
		end
end
go
