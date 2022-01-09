CREATE TABLE [dbo].[Supply](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
 
    CONSTRAINT [PK_Supply] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
)