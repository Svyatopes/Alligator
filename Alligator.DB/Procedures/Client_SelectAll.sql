CREATE PROCEDURE dbo.Client_SelectAll
AS
BEGIN
	SELECT
		cl.Id,
		cl.FirstName,
		cl.LastName,
		cl.Patronymic,
		cl.PhoneNumber,
		cl.Email,
		co.Id,
		co.Text,
		co.ClientId
	from dbo.[Client] cl inner join dbo.[Comment] co on cl.Id = co.ClientId
end
