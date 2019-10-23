CREATE PROCEDURE ContentTypeIndexGet (@LanguageId int)
AS
SELECT 
	dbContentTypeLanguage.Id
	, dbContentTypeLanguage.Name
	, dbContentTypeLanguage.Description
	, dbContentTypeLanguage.MouseOver
	, dbContentTypeLanguage.MenuName
FROM dbContentTypeLanguage
WHERE dbContentTypeLanguage.LanguageId = @LanguageId
ORDER BY dbContentTypeLanguage.Name