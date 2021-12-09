CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL, 
    CONSTRAINT [PK_Product_Category] PRIMARY KEY CLUSTERED  
(
	[Id] ASC
)
, UNIQUE NONCLUSTERED 
(
	[Name] ASC
)
)