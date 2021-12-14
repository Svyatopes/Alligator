CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[CategoryId] INT NOT NULL, 
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
),UNIQUE NONCLUSTERED 
(
	[Name] ASC,
	[CategoryId] ASC
))
GO

ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
