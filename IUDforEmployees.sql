use TikhonovTR
go

create procedure Update_Employees_JobStat
	@IDEmp  int,
	@Job nvarchar(30)
as
	set nocount on;
	set xact_abort on;
	update Employees
	set 
	JobStatus=@Job
	where IDEmployees = @IDEmp
go



create procedure Input_Employees
	@Sur nvarchar(30),
	@Firs nvarchar(30),
	@Las nvarchar(30),
	@Pos nvarchar(30),
	@Sal money,
	@Job nvarchar(30),
	@Busy bit
as
	set nocount on;
	set xact_abort on;
	insert into Employees
	values (
		@Sur,
		@Firs,
		@Las,
		@Pos,
		@Sal,
		@Job,
		@Busy
	)
go

create procedure Update_Employees
	@IDEmp int,
	@Sur nvarchar(30),
	@Firs nvarchar(30),
	@Las nvarchar(30),
	@Pos nvarchar(30),
	@Sal money,
	@Job nvarchar(30)
as
	set nocount on;
	set xact_abort on;
	update Employees
	set 
	Surname=@Sur ,
	Firstname=@Firs,
	Lastname=@Las,
	Position=@Pos,
	Salary=@Sal,
	JobStatus=@Job
	where IDEmployees = @IDEmp 
go

create procedure Update_Employees_Busy
	@IDEmp  int,
	@Busy bit
as
	set nocount on;
	set xact_abort on;
	update Employees
	set 
	BusyStatus=@Busy
	where IDEmployees = @IDEmp
go

create procedure Delete__Employees
	@IDEmp int
as
	set nocount on;
	set xact_abort on;
	delete from Employees
	where IDEmployees = @IDEmp
go