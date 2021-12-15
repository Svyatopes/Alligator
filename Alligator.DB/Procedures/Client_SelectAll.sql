CREATE PROCEDURE dbo.Client_SelectAll
AS
BEGIN
	SELECT 
	Id,
	FirstName,
	LastName,
	Patronymic,
	PhoneNumber,
	Email
FROM dbo.Client
END
