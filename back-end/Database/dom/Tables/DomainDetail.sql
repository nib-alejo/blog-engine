CREATE TABLE [dom].[DomainDetail] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [DomainId]    UNIQUEIDENTIFIER NOT NULL,
    [Description] VARCHAR (50)     NOT NULL,
    [Active]      BIT              NOT NULL,
    CONSTRAINT [PK_DomainDetail] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_DomainDetail_Domain] FOREIGN KEY ([DomainId]) REFERENCES [dom].[Domain] ([Id])
);

