CREATE PROCEDURE dbo.Client_SelectAll
AS
begin 
	SELECT 
	Id,
	FirstName,
	LastName,
	Patronymic,
	PhoneNumber,
	Email
from dbo.Client
end
