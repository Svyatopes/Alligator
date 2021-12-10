CREATE TABLE [dbo].[Comment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [varchar](300) NOT NULL,
	[ClientId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
),

) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
GO

ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Client]
GO
