CREATE TABLE [dom].[Domain] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Description] VARCHAR (50)     NOT NULL,
    CONSTRAINT [PK_Domain] PRIMARY KEY CLUSTERED ([Id] ASC)
);

