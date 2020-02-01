CREATE PROCEDURE ContentTypeGroupIndexGet (@LanguageId int)
AS
SELECT 
	dbContentTypeGroupLanguage.Id
	, ISNULL(dbContentTypeGroupLanguage.Name,'') Name
	, ISNULL(dbContentTypeGroupLanguage.Description,'') Description
	, ISNULL(dbContentTypeGroupLanguage.MouseOver,'') MouseOver
	, ISNULL(dbContentTypeGroupLanguage.MenuName,'') MenuName
FROM dbContentTypeGroupLanguage
WHERE dbContentTypeGroupLanguage.LanguageId = @LanguageId
ORDER BY dbContentTypeGroupLanguage.Name
