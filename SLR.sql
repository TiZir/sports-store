use TikhonovTR
go

exec sp_configure 'show advanced options',1;
go
reconfigure;
go

exec sp_configure 'clr enabled',1;
go
reconfigure;
go

exec sp_configure 'clr strict security',0;
go
reconfigure;
go


Create assembly CLRFunc
from 'C:\Users\Pedruchio\source\repos\TikhonovCLR\TikhonovCLR\bin\Release\TikhonovCLR.dll'
with permission_set=safe
go

Create function dbo.PhoneN(@str nvarchar(15))
returns bit
as external name CLRFunc.CLR_Tikhonov.PhoneNumber;
go

Create function dbo.UpperW(@str nvarchar(60))
returns nvarchar(15)
as external name CLRFunc.CLR_Tikhonov.CheckUpper;
go