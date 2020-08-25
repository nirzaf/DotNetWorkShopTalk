-- <Migration ID="b86e9ff7-87a2-499c-a390-a280e1139a24" />
GO

PRINT N'Creating [dbo].[Orders]'
GO
CREATE TABLE [dbo].[Orders]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[CustomerID] [int] NOT NULL,
[Street] [varchar] (150) NOT NULL,
[City] [varchar] (100) NOT NULL,
[State] [varchar] (2) NOT NULL,
[Zip] [varchar] (5) NOT NULL,
[DateTimeOrdered] [datetime2] NOT NULL,
[DateTimeSentOutForDelivery] [datetime2] NULL,
[DateTimeDelivered] [nchar] (10) NULL
)
GO
PRINT N'Creating primary key [PK_Orders] on [dbo].[Orders]'
GO
ALTER TABLE [dbo].[Orders] ADD CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED  ([ID])
GO
PRINT N'Creating [dbo].[OrderLineItems]'
GO
CREATE TABLE [dbo].[OrderLineItems]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[ProductID] [int] NOT NULL,
[OrderID] [int] NOT NULL
)
GO
PRINT N'Creating primary key [PK_OrderLineItems] on [dbo].[OrderLineItems]'
GO
ALTER TABLE [dbo].[OrderLineItems] ADD CONSTRAINT [PK_OrderLineItems] PRIMARY KEY CLUSTERED  ([ID])
GO
PRINT N'Creating [dbo].[Products]'
GO
CREATE TABLE [dbo].[Products]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Name] [varchar] (100) NOT NULL,
[Amount] [money] NOT NULL
)
GO
PRINT N'Creating primary key [PK_Products] on [dbo].[Products]'
GO
ALTER TABLE [dbo].[Products] ADD CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED  ([ID])
GO
PRINT N'Creating [dbo].[Customers]'
GO
CREATE TABLE [dbo].[Customers]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[FullName] [varchar] (150) NOT NULL,
[Street] [varchar] (100) NOT NULL,
[City] [varchar] (100) NOT NULL,
[State] [varchar] (2) NOT NULL,
[Zip] [varchar] (5) NOT NULL
)
GO
PRINT N'Creating primary key [PK_Customers] on [dbo].[Customers]'
GO
ALTER TABLE [dbo].[Customers] ADD CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED  ([ID])
GO
PRINT N'Adding foreign keys to [dbo].[Orders]'
GO
ALTER TABLE [dbo].[Orders] ADD CONSTRAINT [FK_Orders_Customers] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customers] ([ID])
GO
PRINT N'Adding foreign keys to [dbo].[OrderLineItems]'
GO
ALTER TABLE [dbo].[OrderLineItems] ADD CONSTRAINT [FK_OrderLineItems_Products] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ID])
GO
ALTER TABLE [dbo].[OrderLineItems] ADD CONSTRAINT [FK_OrderLineItems_Orders] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Orders] ([ID])
GO
