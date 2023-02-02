use TikhonovTR
go

create procedure Input_Users
	@Sur nvarchar(30),
	@First nvarchar(30),
	@Last nvarchar(30),
	@Phone nvarchar(15),
	@Email nvarchar(30)
as
	set nocount on;
	set xact_abort on;
	insert into Users
	values (
		@Sur,
		@First,
		@Last,
		@Phone,
		@Email
	)
go

create procedure Update_Users
	@IDUs int,
	@Sur nvarchar(30),
	@First nvarchar(30),
	@Last nvarchar(30),
	@Phone nvarchar(15)
as
	set nocount on;
	set xact_abort on;
	update Users
	set 
		Surname=@Sur,
		Firstname=@First,
		Lastname=@Last,
		Phone=@Phone
	where IDUsers = @IDUs 
go

create procedure Update_Users_Email
	@IDUs int,
	@Email nvarchar(30)
as
	set nocount on;
	set xact_abort on;
	update Users
	set 
	Email=@Email
	where IDUsers = @IDUs
go


create procedure Delete_Users
	@IDUs int
as
	set nocount on;
	set xact_abort on;
	delete from Users
	where IDUsers = @IDUs
go