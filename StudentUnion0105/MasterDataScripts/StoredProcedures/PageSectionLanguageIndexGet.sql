CREATE PROCEDURE PageSectionLanguageIndexGet (@Id int)
AS
SELECT 
dbLanguage.LanguageName
	, dbPageSectionLanguage.Id
	, dbPageSectionLanguage.Name
	, dbPageSectionLanguage.Description
	, dbPageSectionLanguage.MouseOver
	, dbPageSectionLanguage.MenuName
FROM dbPageSectionLanguage
JOIN dbLanguage 
	ON dbPageSectionLanguage.LanguageId = dbLanguage.Id
WHERE dbPageSectionLanguage.PageSectionId = @Id
ORDER BY dbLanguage.LanguageName
