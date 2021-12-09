CREATE PROCEDURE dbo.Client_SelectAll
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



