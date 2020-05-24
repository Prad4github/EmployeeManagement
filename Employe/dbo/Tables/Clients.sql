CREATE TABLE [dbo].[Clients]
(
[ClientId] uniqueidentifier NOT NULL default newid(),
[ClientName] NVARCHAR (200) NOT NULL,
[Alias] NVARCHAR (1000) NULL,
[Email] NVARCHAR (1000) NULL,
[FirstName] NVARCHAR (1000) NULL,
[LastName] NVARCHAR (1000) NULL,
[ManagerId] uniqueidentifier NULL,
[Level] INT NOT NULL,
CONSTRAINT [PK_Domain.Clients] PRIMARY KEY CLUSTERED([ClientId] ASC),
CONSTRAINT client_fk FOREIGN KEY([ManagerId])
        REFERENCES [Managers]([ManagerId])
        ON Delete CASCADE 
)
