﻿CREATE PROCEDURE dbo.Insert_Client
	@FirstName varchar(50),
    @LastName varchar(50),
    @Patronymic varchar(50),
    @PhoneNumber varchar(50),
    @Email varchar(50)
AS
INSERT INTO dbo.Client
           (FirstName,
            LastName,
            Patronymic,
            PhoneNumber,
            Email)
     VALUES
           (@FirstName
           ,@LastName
           ,@Patronymic
           ,@PhoneNumber
           ,@Email)
           GO
