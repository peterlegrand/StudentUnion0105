CREATE PROCEDURE PageSectionLanguageIndexGet (@Id int)
AS
SELECT 
dbLanguage.LanguageName
	, dbPageSectionLanguage.Id LId
	, dbPageSectionLanguage.Name
	, dbPageSectionLanguage.Description
	, dbPageSectionLanguage.MouseOver
	, dbPageSectionLanguage.MenuName
	, dbPageSectionLanguage.PageSectionId OId
	, dbPageSection.PageId PId
FROM dbPageSectionLanguage
JOIN dbLanguage 
	ON dbPageSectionLanguage.LanguageId = dbLanguage.Id
JOIN dbPageSection
	ON dbPageSection.Id = dbPageSectionLanguage.PageSectionId
WHERE dbPageSectionLanguage.PageSectionId = @Id
ORDER BY dbLanguage.LanguageName
