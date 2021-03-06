/****** Object:  Table [dom].[DomainDetail]    Script Date: 2021-01-16 11:51:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dom].[DomainDetail](
	[Id] [uniqueidentifier] NOT NULL,
	[DomainId] [uniqueidentifier] NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_DomainDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dom].[DomainDetail]  WITH CHECK ADD  CONSTRAINT [FK_DomainDetail_Domain] FOREIGN KEY([DomainId])
REFERENCES [dom].[Domain] ([Id])
GO
ALTER TABLE [dom].[DomainDetail] CHECK CONSTRAINT [FK_DomainDetail_Domain]
GO
