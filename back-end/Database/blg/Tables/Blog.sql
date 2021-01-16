CREATE TABLE [blg].[Blog] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [AuthorId]    UNIQUEIDENTIFIER NOT NULL,
    [StateId]     UNIQUEIDENTIFIER NOT NULL,
    [Title]       VARCHAR (100)    NOT NULL,
    [Article]     VARCHAR (2000)   NOT NULL,
    [Date]        DATETIME         NOT NULL,
    [PublishDate] DATETIME         NULL,
    CONSTRAINT [PK_Blog] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Blog_Employee] FOREIGN KEY ([AuthorId]) REFERENCES [blg].[Employee] ([Id])
);

