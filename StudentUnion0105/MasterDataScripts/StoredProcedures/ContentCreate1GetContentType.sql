CREATE PROCEDURE ContentCreate1GetContentType (@CurrentUser nvarchar(50), @PId int) 
AS
SELECT 
	DbContentType.ContentTypeGroupId PId
	, DbContentType.Id 
	, DbContentTypeLanguage.Name
FROM DbContentType
JOIN DbContentTypeLanguage
	ON DbContentType.Id = DbContentTypeLanguage.ContentTypeId
JOIN AspNetUsers
	ON AspNetUsers.SecurityLevel >= dbContentType.SecurityLevel
WHERE LanguageId = AspNetUsers.DefaultLanguageId
	AND DbContentType.ContentTypeGroupId = @PId
	AND AspNetUsers.Id = @CurrentUser
ORDER BY 
	DbContentTypeLanguage.Name
