CREATE PROCEDURE FrontOrganizationDashboardGetContent (@OrganizationId int, @CurrentUser nvarchar(50))
AS
SELECT 
	DbContent.Id
	, DbContent.Title
	, DbContentTypeLanguage.Name ContentTypeName
	, DbContentStatus.Name ContentStatusName
	, Creator.UserName Creator
	, DbContent.CreatedDate
	, Modifier.UserName Modifier
	, DbContent.ModifiedDate
FROM DbContent 
JOIN AspNetUsers CurrentUser
	ON DbContent.SecurityLevel <= CurrentUser.SecurityLevel
JOIN AspNetUsers Creator
	ON dbcontent.CreatorId = Creator.Id
JOIN AspNetUsers Modifier
	ON dbcontent.CreatorId = Modifier.Id
JOIN DbContentTypeLanguage
	ON DbContent.ContentTypeId = DbContentTypeLanguage.ContentTypeId
JOIN DbContentStatus
	ON DbContent.ContentStatusId = DbContentStatus.Id
WHERE dbcontent.OrganizationId = @OrganizationId
	AND currentuser.Id= @CurrentUser
	AND DbContentTypeLanguage.LanguageId = CurrentUser.DefaultLanguageId