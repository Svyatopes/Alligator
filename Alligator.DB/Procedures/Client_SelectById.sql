﻿CREATE PROC dbo.ClientSelectById
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