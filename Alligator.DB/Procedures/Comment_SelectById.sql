CREATE PROC dbo.Comment_SelectById
@Id int
AS
BEGIN
	select
	co.Id,
	co.Text,
	co.ClientId,
	c.Id,
	c.FirstName,
	c.LastName,
	c.Email,
	c.PhoneNumber
	FROM dbo.[Comment] co inner join dbo.[Client] c on co.[ClientId]=c.Id
END
