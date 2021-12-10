CREATE PROC dbo.Client_SelectById
	@Id int
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
	where Id = @Id;
end