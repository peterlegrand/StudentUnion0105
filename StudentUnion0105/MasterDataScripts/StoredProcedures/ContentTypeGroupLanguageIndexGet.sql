CREATE PROCEDURE ContentTypeGroupLanguageIndexGet (@OId int)
AS
SELECT 
	 dbContentTypeGroupLanguage.Id LId
	, dbContentTypeGroupLanguage.ContentTypeGroupId OId
	, 0 PId
	, ISNULL(dbContentTypeGroupLanguage.Name,'') Name
	, ISNULL(dbContentTypeGroupLanguage.Description,'') Description 
	, ISNULL(dbContentTypeGroupLanguage.MouseOver,'') MouseOver
	, ISNULL(dbContentTypeGroupLanguage.MenuName,'') MenuName
	, dbLanguage.Id LanguageId
	, ISNULL(dbLanguage.LanguageName,'') LanguageName
FROM dbContentTypeGroupLanguage
JOIN dbLanguage 
	ON dbContentTypeGroupLanguage.LanguageId = dbLanguage.Id
WHERE dbContentTypeGroupLanguage.ContentTypeGroupId = @OId
ORDER BY dbLanguage.LanguageName
