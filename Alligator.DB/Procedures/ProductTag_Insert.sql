﻿CREATE proc dbo.ProductTag_Insert
			@Name varchar(50)
AS
BEGIN
	INSERT INTO dbo.ProductTag (Name)
	OUTPUT Inserted.ID
	VALUES (@Name)
END
