CREATE PROCEDURE ContentTypeLanguageIndexGet (@OId int)
AS
SELECT 
	dbContentTypeLanguage.Id LId
	, dbContentTypeLanguage.ContentTypeId OId
	, 0 PId
	, ISNULL(dbContentTypeLanguage.Name,'') Name
	, ISNULL(dbContentTypeLanguage.Description, '') Description
	, ISNULL(dbContentTypeLanguage.MouseOver, '') MouseOver
	, ISNULL(dbContentTypeLanguage.MenuName, '') MenuName
	, dbLanguage.Id LanguageId
	, ISNULL(dbLanguage.LanguageName,'') LanguageName
FROM dbContentTypeLanguage
JOIN dbLanguage 
	ON dbContentTypeLanguage.LanguageId = dbLanguage.Id
WHERE dbContentTypeLanguage.ContentTypeId = @OId
ORDER BY dbLanguage.LanguageName
