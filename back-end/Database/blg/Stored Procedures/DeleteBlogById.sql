CREATE procedure [blg].[DeleteBlogById]
(
	@id uniqueidentifier
)
as

set nocount on;


delete blg.Blog
where Id = @id