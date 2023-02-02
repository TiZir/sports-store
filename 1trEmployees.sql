use TikhonovTR
go


create trigger StatWork on Employees
after update
as
declare @IDEmp int,@Sal money, @JobStat nvarchar(30)
begin
	select  @IDEmp=IDEmployees,@Sal=Salary, @JobStat=dbo.UpperW(JobStatus)  from inserted

	if(@JobStat='Больничный')
		begin
			update Employees SET BusyStatus=1 where IDEmployees=@IDEmp
			update Employees SET Salary=Salary-@SaL*0.2 where IDEmployees=@IDEmp
		end
	if(@JobStat='Отпуск')
		begin
			update Employees SET BusyStatus=1 where IDEmployees=@IDEmp
			update Employees SET Salary=Salary-@SaL*0.4 where IDEmployees=@IDEmp
		end
end
go


create trigger CheckNameEmp on Employees
instead of insert
as
declare @Sur nvarchar(30), @First nvarchar(30), @Last nvarchar(30), @Position nvarchar(30), @Sal money,
@JobStat nvarchar(30), @BusyStat bit
begin
	select @Sur=dbo.UpperW(Surname), @First=dbo.UpperW(Firstname) , @Last=dbo.UpperW(Lastname),
	@Position=dbo.UpperW(Position), @Sal=Salary, @JobStat=dbo.UpperW(JobStatus) , @BusyStat=BusyStatus  from inserted

	if(@JobStat='Больничный')
		begin
			SET @BusyStat=1
			SET @Sal=@Sal-@SaL*0.2
		end
	if(@JobStat='Отпуск')
		begin
			SET @BusyStat=1
			SET @Sal=@Sal-@SaL*0.4
		end
	
	insert into Employees
	values(@Sur, @First, @Last, @Position, @Sal, @JobStat , @BusyStat)
	
end
go
