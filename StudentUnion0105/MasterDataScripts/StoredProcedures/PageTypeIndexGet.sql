CREATE PROCEDURE PageTypeIndexGet (@LanguageId int)
AS
SELECT 
	dbPageTypeLanguage.Id
	, dbPageTypeLanguage.Name
	, dbPageTypeLanguage.Description
	, dbPageTypeLanguage.MouseOver
	, dbPageTypeLanguage.MenuName
FROM dbPageTypeLanguage
WHERE dbPageTypeLanguage.LanguageId = @LanguageId
ORDER BY dbPageTypeLanguage.Name