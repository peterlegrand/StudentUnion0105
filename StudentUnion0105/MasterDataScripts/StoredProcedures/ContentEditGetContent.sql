CREATE PROCEDURE ContentEditGetContent (@Id int)
AS
SELECT 
	DbContent.Id 
	, DbContent.ContentTypeId
	, DbContentType.ProcessTemplateId
	, DbContent.ContentStatusId
	, DbContent.LanguageId
	, DbContent.Title
	, DbContent.Description
	, DbContent.SecurityLevel
	, ISNULL(DbContent.OrganizationId,0) OrganizationId
	, ISNULL(DbContent.ProjectId,0) ProjectId
	, Creator.UserName Creator
	, DbContent.CreatedDate
	, Modifier.UserName Modifier
	, DbContent.ModifiedDate
FROM DbContent
JOIN DbContentType
	ON DbContent.ContentTypeId = DbContentType.Id
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), DbContent.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), DbContent.ModifierId) = Modifier.Id
WHERE DbContent.Id = @Id