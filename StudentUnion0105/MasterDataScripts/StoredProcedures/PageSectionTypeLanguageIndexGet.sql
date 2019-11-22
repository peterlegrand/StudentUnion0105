CREATE PROCEDURE PageSectionTypeLanguageIndexGet (@Id int)
AS
SELECT 
dbLanguage.LanguageName
	, dbPageSectionTypeLanguage.Id LId
	, dbPageSectionTypeLanguage.Name
	, dbPageSectionTypeLanguage.Description
	, dbPageSectionTypeLanguage.MouseOver
	, dbPageSectionTypeLanguage.MenuName
	, dbPageSectionTypeLanguage.PageSectionTypeId OId
	, 0 PId
FROM dbPageSectionTypeLanguage
JOIN dbLanguage 
	ON dbPageSectionTypeLanguage.LanguageId = dbLanguage.Id
WHERE dbPageSectionTypeLanguage.PageSectionTypeId = @Id
ORDER BY dbLanguage.LanguageName
