create function [dom].[GetDomainDetailDescriptionById](@id uniqueidentifier)
returns varchar(50)
as
begin
    return (select Description from dom.DomainDetail where Id = @id)
end