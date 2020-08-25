CREATE TABLE [dbo].[Customers]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[FullName] [varchar] (150) NOT NULL,
[Street] [varchar] (100) NOT NULL,
[City] [varchar] (100) NOT NULL,
[State] [varchar] (2) NOT NULL,
[Zip] [varchar] (5) NOT NULL,
[NumberOfPets] [bigint] NOT NULL
)
GO
ALTER TABLE [dbo].[Customers] ADD CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED  ([ID])
GO
