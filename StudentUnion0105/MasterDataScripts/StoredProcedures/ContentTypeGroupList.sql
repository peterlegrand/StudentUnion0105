CREATE PROCEDURE ContentTypeGroupList (@LanguageId int) 
AS
SELECT 
	DbContentTypeGroupLanguage.Id
	, DbContentTypeGroupLanguage.Name 
FROM DbContentTypeGroupLanguage 
WHERE DbContentTypeGroupLanguage.LanguageId = @LanguageId
ORDER BY DbContentTypeGroupLanguage.Name