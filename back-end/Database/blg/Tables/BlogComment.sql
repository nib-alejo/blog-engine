CREATE TABLE [blg].[BlogComment] (
    [Id]      UNIQUEIDENTIFIER NOT NULL,
    [BlogId]  UNIQUEIDENTIFIER NOT NULL,
    [Comment] VARCHAR (2000)   NOT NULL,
    [Date]    DATETIME         NOT NULL,
    CONSTRAINT [PK_BlogComment] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BlogComment_Blog] FOREIGN KEY ([BlogId]) REFERENCES [blg].[Blog] ([Id])
);

