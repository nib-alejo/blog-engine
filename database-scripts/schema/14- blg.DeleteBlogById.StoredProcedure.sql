/****** Object:  StoredProcedure [blg].[DeleteBlogById]    Script Date: 2021-01-16 11:51:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [blg].[DeleteBlogById]
(
	@id uniqueidentifier
)
as

set nocount on;


delete blg.Blog
where Id = @id
GO
