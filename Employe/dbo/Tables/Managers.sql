CREATE TABLE [dbo].[Managers]
(
[ManagerId] uniqueidentifier NOT NULL default newid(),
[ManagerName] NVARCHAR (200) NOT NULL,
[Email] NVARCHAR(1000) NULL,
[Alias] NVARCHAR (1000) NULL,
[FirstName] NVARCHAR (1000) NULL,
[LastName] NVARCHAR (1000) NULL,
[Positon] Int NOT NULL
CONSTRAINT [PK_Domain.Managers] PRIMARY KEY CLUSTERED ([ManagerId] ASC)
)
