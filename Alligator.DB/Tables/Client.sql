CREATE TABLE [dbo].[Client]
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Patronymic] [varchar](50) NULL,
	[PhoneNumber] [varchar](50) NOT NULL,
	[Email] [varchar](200) NULL,
	CONSTRAINT PK_Client PRIMARY KEY CLUSTERED
	(
	[Id] ASC
	),
	UNIQUE NONCLUSTERED
	(
		[Email] ASC
	)

	
)
GO