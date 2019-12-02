CREATE PROCEDURE PageTypeLanguageIndexGet (@OId int)
AS
SELECT 
	dbPageTypeLanguage.Id LId
	, dbPageTypeLanguage.PageTypeId OId
	, 0 PId
	, ISNULL(dbPageTypeLanguage.Name,'') Name
	, ISNULL(dbPageTypeLanguage.Description,'') Description
	, ISNULL(dbPageTypeLanguage.MouseOver,'') MouseOver
	, ISNULL(dbPageTypeLanguage.MenuName,'') MenuName
	, dbLanguage.Id LanguageId
	, ISNULL(dbLanguage.LanguageName,'') LanguageName
FROM dbPageTypeLanguage
JOIN dbLanguage
	ON dbLanguage.Id = dbPageTypeLanguage.LanguageId
WHERE dbPageTypeLanguage.PageTypeId = @OId
ORDER BY dbPageTypeLanguage.Name
