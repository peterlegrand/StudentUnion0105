CREATE PROCEDURE ContentTypeLanguageIndexGet (@Id int)
AS
SELECT 
dbLanguage.LanguageName
	, dbContentTypeLanguage.Id
	, dbContentTypeLanguage.Name
	, dbContentTypeLanguage.Description
	, dbContentTypeLanguage.MouseOver
	, dbContentTypeLanguage.MenuName
	, 0 PId
FROM dbContentTypeLanguage
JOIN dbLanguage 
	ON dbContentTypeLanguage.LanguageId = dbLanguage.Id
WHERE dbContentTypeLanguage.ContentTypeId = @Id
ORDER BY dbLanguage.LanguageName
