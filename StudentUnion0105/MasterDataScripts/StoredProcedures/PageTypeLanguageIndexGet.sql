CREATE PROCEDURE PageTypeLanguageIndexGet (@Id int)
AS
SELECT 
	dbPageTypeLanguage.Id LId
	, dbPageTypeLanguage.Name
	, dbPageTypeLanguage.Description
	, dbPageTypeLanguage.MouseOver
	, dbPageTypeLanguage.MenuName
	, dbLanguage.LanguageName
	, dbPageTypeLanguage.PageTypeId OId
	, 0 PId
FROM dbPageTypeLanguage
JOIN dbLanguage
	ON dbLanguage.Id = dbPageTypeLanguage.LanguageId
WHERE dbPageTypeLanguage.PageTypeId = @Id
ORDER BY dbPageTypeLanguage.Name
