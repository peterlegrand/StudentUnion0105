CREATE PROCEDURE PageSectionTypeLanguageIndexGet (@Id int)
AS
SELECT 
dbLanguage.LanguageName
	, dbPageSectionTypeLanguage.Id
	, dbPageSectionTypeLanguage.Name
	, dbPageSectionTypeLanguage.Description
	, dbPageSectionTypeLanguage.MouseOver
	, dbPageSectionTypeLanguage.MenuName
FROM dbPageSectionTypeLanguage
JOIN dbLanguage 
	ON dbPageSectionTypeLanguage.LanguageId = dbLanguage.Id
WHERE dbPageSectionTypeLanguage.PageSectionTypeId = @Id
ORDER BY dbLanguage.LanguageName
