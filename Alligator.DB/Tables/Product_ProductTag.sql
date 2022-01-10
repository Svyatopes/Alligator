CREATE TABLE [dbo].[Product_ProductTag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[ProductTagId] [int] NOT NULL,
 CONSTRAINT [PK_Product_ProductTag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
),UNIQUE NONCLUSTERED 
(
	[ProductId] ASC,
	[ProductTagId] ASC
)) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Product_ProductTag]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductTag_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Product_ProductTag] CHECK CONSTRAINT [FK_Product_ProductTag_Product]
GO

ALTER TABLE [dbo].[Product_ProductTag]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductTag_ProductTag] FOREIGN KEY([ProductTagId])
REFERENCES [dbo].[ProductTag] ([Id])
GO

ALTER TABLE [dbo].[Product_ProductTag] CHECK CONSTRAINT [FK_Product_ProductTag_ProductTag]
GO
