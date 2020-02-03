CREATE PROCEDURE ContentCreate1GetContentType (@LanguageId int, @PId int) 
AS
SELECT 
	DbContentType.ContentTypeGroupId PId
	, DbContentType.Id 
	, DbContentTypeLanguage.Name
FROM DbContentType
JOIN DbContentTypeLanguage
	ON DbContentType.Id = DbContentTypeLanguage.ContentTypeId
WHERE LanguageId = @LanguageId
	AND DbContentType.ContentTypeGroupId = @PId
ORDER BY 
	DbContentTypeLanguage.Name