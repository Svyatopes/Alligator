CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[CategoryId] INT NOT NULL, 
    PRIMARY KEY CLUSTERED 
(
	[Id] ASC
),UNIQUE NONCLUSTERED 
(
	[Name] ASC,
	[CategoryId] ASC
))
