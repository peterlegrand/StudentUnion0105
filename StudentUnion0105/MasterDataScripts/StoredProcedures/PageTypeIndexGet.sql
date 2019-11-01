CREATE PROCEDURE PageTypeIndexGet (@LanguageId int)
AS
SELECT 
	dbPageTypeLanguage.Id
	, ISNULL(dbPageTypeLanguage.Name,'') Name
	, ISNULL(dbPageTypeLanguage.Description,'') Description
	, ISNULL(dbPageTypeLanguage.MouseOver,'') MouseOver
	, ISNULL(dbPageTypeLanguage.MenuName,'') MenuName
FROM dbPageTypeLanguage
WHERE dbPageTypeLanguage.LanguageId = @LanguageId
ORDER BY dbPageTypeLanguage.Name