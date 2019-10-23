CREATE PROCEDURE PageSectionTypeIndexGet (@LanguageId int)
AS
SELECT 
	dbPageSectionTypeLanguage.Id
	, dbPageSectionTypeLanguage.Name
	, dbPageSectionTypeLanguage.Description
	, dbPageSectionTypeLanguage.MouseOver
	, dbPageSectionTypeLanguage.MenuName
FROM dbPageSectionTypeLanguage
WHERE dbPageSectionTypeLanguage.LanguageId = @LanguageId
ORDER BY dbPageSectionTypeLanguage.Name