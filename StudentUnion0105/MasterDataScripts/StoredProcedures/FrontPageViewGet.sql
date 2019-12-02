CREATE PROCEDURE FrontPageViewGet (
	@LanguageId int
	, 	@Id int
	)
AS
SELECT 
	dbContent.Id
	, dbContent.Title
	, dbContent.Description
	, dbContent.SecurityLevel
	, dbContent.CreatedDate
	, dbContent.ModifiedDate
	, Creator.UserName Creator
	, Modifier.UserName Modifier
	, dbContentStatus.Name StatusName
	, dbContentTypeLanguage.Name TypeName
	, dbOrganizationLanguage.Name OrganizationName
FROM dbContent
JOIN AspNetUsers Creator
	ON dbContent.CreatorId = Creator.Id
JOIN AspNetUsers Modifier
	ON dbContent.ModifierId = Modifier.Id
JOIN dbContentType
	ON dbContent.ContentTypeId = dbContentType.Id
JOIN dbContentTypeLanguage
	ON dbContentType.Id = dbContentTypeLanguage.ContentTypeId
JOIN dbContentStatus
	ON dbContent.ContentStatusId = dbContentStatus.Id
JOIN dbLanguage ContentLanguage
	ON dbContent.LanguageId = ContentLanguage.Id
JOIN dbOrganization
	 ON dbContent.OrganizationId = dbOrganization.Id
JOIN dbOrganizationLanguage
	ON dbOrganization.Id = dbOrganizationLanguage.OrganizationId
WHERE dbContentTypeLanguage.LanguageId = @LanguageId
	AND dbOrganizationLanguage.LanguageId = @LanguageId
	AND dbContent.Id = @Id