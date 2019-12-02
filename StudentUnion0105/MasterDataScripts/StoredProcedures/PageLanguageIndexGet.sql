CREATE PROCEDURE PageLanguageIndexGet (@OId int)
AS
SELECT 
	dbPageLanguage.Id LId
	, dbPageLanguage.PageId OId
	, 0 PId
	, ISNULL(dbPageLanguage.Name,'') Name
	, ISNULL(dbPageLanguage.Description,'') Description
	, ISNULL(dbPageLanguage.MouseOver,'') MouseOver
	, ISNULL(dbPageLanguage.MenuName,'') MenuName
	, dbLanguage.Id LanguageId
	, ISNULL(dbLanguage.LanguageName,'') LanguageName
FROM dbPageLanguage
JOIN dbLanguage 
	ON dbPageLanguage.LanguageId = dbLanguage.Id
WHERE dbPageLanguage.PageId = @OId
ORDER BY dbLanguage.LanguageName
