CREATE procedure [blg].[UpdateBlog]
(
	@blogList varchar(max)
)
as

set nocount on;


update blo
	set blo.AuthorId = #blo.AuthorId
		,blo.StateId = #blo.StateId
		,blo.Title = #blo.Title
		,blo.Article = #blo.Article
		,blo.Date = #blo.Date
		,blo.PublishDate = #blo.PublishDate

from blg.Blog as blo
	join openjson(@blogList) with (
		Id uniqueidentifier
		,AuthorId uniqueidentifier '$.Author.Id'
		,StateId uniqueidentifier '$.State.Id'
		,Title varchar(100)
		,Article varchar(2000)
		,Date datetime
		,PublishDate datetime
	) as #blo on blo.Id = #blo.Id