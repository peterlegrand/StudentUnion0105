CREATE PROCEDURE PageSectionLanguageIndexGet (@OId int)
AS
SELECT 
	dbPageSectionLanguage.Id LId
	, dbPageSectionLanguage.PageSectionId OId
	, dbPageSection.PageId PId
	, ISNULL(dbPageSectionLanguage.Name,'') Name
	, ISNULL(dbPageSectionLanguage.Description,'') Description
	, ISNULL(dbPageSectionLanguage.MouseOver,'') MouseOver
	, ISNULL(dbPageSectionLanguage.MenuName,'') MenuName
	, dbLanguage.Id LanguageId
	, ISNULL(dbLanguage.LanguageName,'') LanguageName
FROM dbPageSectionLanguage
JOIN dbLanguage 
	ON dbPageSectionLanguage.LanguageId = dbLanguage.Id
JOIN dbPageSection
	ON dbPageSection.Id = dbPageSectionLanguage.PageSectionId
WHERE dbPageSectionLanguage.PageSectionId = @OId
ORDER BY dbLanguage.LanguageName
