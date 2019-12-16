CREATE PROCEDURE ClassificationPageSectionLanguageIndexGet (@OId int)
AS
SELECT 
	dbClassificationPageSectionLanguage.Id LId
	, dbClassificationPageSectionLanguage.PageSectionId OId
	, dbClassificationPageSection.ClassificationPageId PId
	, ISNULL(dbClassificationPageSectionLanguage.Name,'') Name
	, ISNULL(dbClassificationPageSectionLanguage.Description,'') Description
	, ISNULL(dbClassificationPageSectionLanguage.MouseOver,'') MouseOver
	, ISNULL(dbClassificationPageSectionLanguage.MenuName,'') MenuName
	, ISNULL(dbClassificationPageSectionLanguage.TitleName,'') TitleName
	, ISNULL(dbClassificationPageSectionLanguage.TitleDescription,'') TitleDescription
	, dbLanguage.Id LanguageId
	, ISNULL(dbLanguage.LanguageName,'') LanguageName
FROM dbClassificationPageSectionLanguage
JOIN dbLanguage 
	ON dbClassificationPageSectionLanguage.LanguageId = dbLanguage.Id
JOIN dbClassificationPageSection
	ON dbClassificationPageSection.Id = dbClassificationPageSectionLanguage.PageSectionId 
WHERE dbClassificationPageSectionLanguage.PageSectionId = @OId
ORDER BY dbLanguage.LanguageName
