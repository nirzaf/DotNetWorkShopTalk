CREATE TABLE [dbo].[Products]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Name] [varchar] (100) NOT NULL,
[Amount] [money] NOT NULL
)
GO
ALTER TABLE [dbo].[Products] ADD CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED  ([ID])
GO
