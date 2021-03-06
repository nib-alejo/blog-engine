/****** Object:  StoredProcedure [blg].[GetBlogByState]    Script Date: 2021-01-16 11:51:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [blg].[GetBlogByState]
(
	@stateId uniqueidentifier = null
)
as

set nocount on;


select cast(
(
	select blo.Id

		--Author
		,json_query((
			select emp.Id

				--Person
				,per.Id as 'Person.Id'
				,per.Name as 'Person.Name'
				,per.Email as 'Person.Email'

				--Role
				,emp.RoleId as 'Role.Id'

			from blg.Employee as emp
				join per.Person as per on emp.PersonId = per.Id

			where emp.Id = blo.AuthorId

			for json path, without_array_wrapper

		)) as 'Author'
		

		,blo.StateId as 'State.Id'
		,dom.GetDomainDetailDescriptionById(blo.StateId) as 'State.Description'

		,blo.Title
		,blo.Article

		,blo.Date
		,blo.PublishDate
		
	from blg.Blog as blo

	where blo.StateId = isnull(@stateId, blo.StateId)

	for json path

) as varchar(max))
GO
