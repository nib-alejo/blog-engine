/****** Object:  UserDefinedFunction [dom].[GetDomainDetailDescriptionById]    Script Date: 2021-01-16 11:51:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dom].[GetDomainDetailDescriptionById](@id uniqueidentifier)
returns varchar(50)
as
begin
    return (select Description from dom.DomainDetail where Id = @id)
end
GO
