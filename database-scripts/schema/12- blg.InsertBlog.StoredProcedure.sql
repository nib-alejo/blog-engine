/****** Object:  StoredProcedure [blg].[InsertBlog]    Script Date: 2021-01-16 11:51:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [blg].[InsertBlog]
(
	@blogList varchar(max)
)
as

set nocount on;


insert into blg.Blog

select #blo.Id
	,#blo.AuthorId
	,#blo.StateId
	,#blo.Title
	,#blo.Article
	,#blo.Date
	,#blo.PublishDate
	
from openjson(@blogList) with (
		Id uniqueidentifier
		,AuthorId uniqueidentifier '$.Author.Id'
		,StateId uniqueidentifier '$.State.Id'
		,Title varchar(100)
		,Article varchar(2000)
		,Date datetime
		,PublishDate datetime
	) as #blo
GO
