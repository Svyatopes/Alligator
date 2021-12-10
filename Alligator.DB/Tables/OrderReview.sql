CREATE TABLE [dbo].[OrderReview](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[Text] [varchar](300) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
))
GO

ALTER TABLE [dbo].[OrderReview]  WITH CHECK ADD  CONSTRAINT [FK_OrderReview_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO

ALTER TABLE [dbo].[OrderReview] CHECK CONSTRAINT [FK_OrderReview_Order]