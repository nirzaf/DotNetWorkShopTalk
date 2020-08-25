CREATE TABLE [dbo].[OrderLineItems]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[ProductID] [int] NOT NULL,
[OrderID] [int] NOT NULL
)
GO
ALTER TABLE [dbo].[OrderLineItems] ADD CONSTRAINT [PK_OrderLineItems] PRIMARY KEY CLUSTERED  ([ID])
GO
ALTER TABLE [dbo].[OrderLineItems] ADD CONSTRAINT [FK_OrderLineItems_Orders] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Orders] ([ID])
GO
ALTER TABLE [dbo].[OrderLineItems] ADD CONSTRAINT [FK_OrderLineItems_Products] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ID])
GO
