/****** Object:  Table [per].[Person]    Script Date: 2021-01-16 11:51:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [per].[Person](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Email] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
