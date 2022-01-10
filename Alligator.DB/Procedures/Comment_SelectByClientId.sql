create proc dbo.Comment_SelectByClientId
@ClientId int
AS
BEGIN
	select
	co.Id,
	co.Text,
	co.ClientId
	from dbo.[Comment] co
	where co.ClientId=@ClientId
END
