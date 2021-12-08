CREATE PROCEDURE dbo.ClientSelectAll
AS
BEGIN
	SELECT
		Id
		FirstName,
		LastName,
		Patronymic,
		PhoneNumber,
		Email
	from dbo.Client
end



