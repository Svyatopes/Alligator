CREATE TABLE [dbo].[SupplyDetail](
	[Id] [int] NOT NULL,
	[SupplyId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Amount] [int] NOT NULL,
 CONSTRAINT [PK_SupplyDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
) 
GO

ALTER TABLE [dbo].[SupplyDetail]  WITH CHECK ADD  CONSTRAINT [FK_SupplyDetail_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO

ALTER TABLE [dbo].[SupplyDetail] CHECK CONSTRAINT [FK_SupplyDetail_Product]
GO

ALTER TABLE [dbo].[SupplyDetail]  WITH CHECK ADD  CONSTRAINT [FK_SupplyDetail_Supply] FOREIGN KEY([SupplyId])
REFERENCES [dbo].[Supply] ([Id])
GO

ALTER TABLE [dbo].[SupplyDetail] CHECK CONSTRAINT [FK_SupplyDetail_Supply]
GO
