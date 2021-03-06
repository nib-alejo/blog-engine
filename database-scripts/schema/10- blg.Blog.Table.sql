/****** Object:  Table [blg].[Blog]    Script Date: 2021-01-16 11:51:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [blg].[Blog](
	[Id] [uniqueidentifier] NOT NULL,
	[AuthorId] [uniqueidentifier] NOT NULL,
	[StateId] [uniqueidentifier] NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[Article] [varchar](2000) NOT NULL,
	[Date] [datetime] NOT NULL,
	[PublishDate] [datetime] NULL,
 CONSTRAINT [PK_Blog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [blg].[Blog]  WITH CHECK ADD  CONSTRAINT [FK_Blog_Employee] FOREIGN KEY([AuthorId])
REFERENCES [blg].[Employee] ([Id])
GO
ALTER TABLE [blg].[Blog] CHECK CONSTRAINT [FK_Blog_Employee]
GO
