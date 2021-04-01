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
ALTER TABLE [dbo].[Orders] ADD CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED  ([ID])
GO
ALTER TABLE [dbo].[Orders] ADD CONSTRAINT [FK_Orders_Customers] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customers] ([ID])
GO
