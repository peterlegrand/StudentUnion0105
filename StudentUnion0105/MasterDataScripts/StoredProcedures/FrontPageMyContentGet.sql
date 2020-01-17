CREATE PROCEDURE FrontPageMyContentGet (@CurrentUserId nvarchar(50))
AS
DECLARE @LanguageId int
SELECT @LanguageId = DefaultLanguageId FROM AspNetUsers WHERE Id = @CurrentUserId

SELECT 
	Dbcontent.ID
	, DbContent.Title
	, DbContent.CreatedDate
	, DbContent.ModifiedDate
	, DbContentStatus.Name StatusName
	, DbContentTypeLanguage.Name TypeName
	, DbOrganizationLanguage.Name OrganizationName
	, ISNULL(Project.Name, '') ProjectName
FROM DbContent
JOIN DbContentStatus
	ON DbContent.ContentStatusId = DbContentStatus.Id
JOIN DbContentTypeLanguage
	ON DbContentTypeLanguage.ContentTypeId = DbContent.ContentTypeId
JOIN DbOrganizationLanguage
	ON DbOrganizationLanguage.OrganizationId = DbContent.OrganizationId
LEFT JOIN (SELECT DbProjectLanguage.ProjectId, DbProjectLanguage.Name FROM DbProjectLanguage WHERE LanguageId = @LanguageId) Project
	ON Project.ProjectId = DbContent.ProjectId
WHERE DbOrganizationLanguage.LanguageId = @LanguageId
AND DbContent.CreatorId = @CurrentUserId
ORDER BY 
DbContent.CreatedDate DESC