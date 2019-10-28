CREATE PROCEDURE PageTypeLanguageIndexGet (@Id int)
AS
SELECT 
	dbPageTypeLanguage.Id
	, dbPageTypeLanguage.Name
	, dbPageTypeLanguage.Description
	, dbPageTypeLanguage.MouseOver
	, dbPageTypeLanguage.MenuName
	, dbLanguage.LanguageName
FROM dbPageTypeLanguage
JOIN dbLanguage
	ON dbLanguage.Id = dbPageTypeLanguage.LanguageId
WHERE dbPageTypeLanguage.PageTypeId = @Id
ORDER BY dbPageTypeLanguage.Name
