create trigger ADsCost1 on ADs
instead of insert
as
declare @IDCod int, @Growth float, @CostAD money, @Platform nvarchar(12), @NameAD nvarchar(30), @DescAd nvarchar(30)
begin
	select @IDCod=IDCode, @Growth=Growth, @CostAD=CostOfAD, @Platform=PlatformAD, 
	@NameAD=NameOfAD, @DescAd=DescriptionOfAD from inserted
	if (@Platform='YouTube')
		SET @CostAD=@CostAD+@Growth*50
	else begin	
		if(@Platform='Instagram')
			SET @CostAD=@CostAD+@Growth*60
		else begin
			if(@Platform='TikTok')
				SET @CostAD=@CostAD+@Growth*30
		end
	end
	update Products set Products.Demand=Products.Demand+@Growth where @IDCod=Code
	insert into ADs
	values(@IDCod, @Growth, @CostAD, @Platform, @NameAD, @DescAd)
end
go
