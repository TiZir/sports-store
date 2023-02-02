use A_12_18_SautovDS_TR
go
create procedure �����_input
	@�������� nvarchar(30),
	@���� money,
	@����������_��_������ int
as
	set nocount on;
	set xact_abort on;
	insert into �����
	values (
		@��������,
		@����,
		@����������_��_������);
go
create procedure �����_update_�����
	@Id_������ int,
	@����������_��_������ int
as
	set nocount on;
	set xact_abort on;
	update �����
	set ����������_��_������ = @����������_��_������
	where Id_������ = @Id_������
go
create procedure �����_update_��������
	@Id_������ int,
	@�������� int
as
	set nocount on;
	set xact_abort on;
	update �����
	set �������� = @��������
	where Id_������ = @Id_������
go
create procedure �����_update_����
	@Id_������ int,
	@���� int
as
	set nocount on;
	set xact_abort on;
	update �����
	set ���� = @����
	where Id_������ = @Id_������
go
create procedure �����_delete
	@Id_������ int
as
	set nocount on;
	set xact_abort on;
	delete from �����
	where Id_������ = @Id_������
go