use A_12_18_SautovDS_TR
go
create procedure Товар_input
	@Название nvarchar(30),
	@Цена money,
	@Количество_на_складе int
as
	set nocount on;
	set xact_abort on;
	insert into Товар
	values (
		@Название,
		@Цена,
		@Количество_на_складе);
go
create procedure Товар_update_Колво
	@Id_Товара int,
	@Количество_на_складе int
as
	set nocount on;
	set xact_abort on;
	update Товар
	set Количество_на_складе = @Количество_на_складе
	where Id_Товара = @Id_Товара
go
create procedure Товар_update_Название
	@Id_Товара int,
	@Название int
as
	set nocount on;
	set xact_abort on;
	update Товар
	set Название = @Название
	where Id_Товара = @Id_Товара
go
create procedure Товар_update_Цена
	@Id_Товара int,
	@Цена int
as
	set nocount on;
	set xact_abort on;
	update Товар
	set Цена = @Цена
	where Id_Товара = @Id_Товара
go
create procedure Товар_delete
	@Id_Товара int
as
	set nocount on;
	set xact_abort on;
	delete from Товар
	where Id_Товара = @Id_Товара
go