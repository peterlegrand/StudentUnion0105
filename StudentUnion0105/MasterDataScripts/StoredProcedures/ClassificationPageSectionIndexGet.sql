CREATE PROCEDURE ClassificationPageSectionIndexGet (@PId int, @LanguageId int)
AS
SELECT 
	dbClassificationPageSection.Id
	, dbClassificationPageSectionLanguage.Name
	, dbClassificationPageSectionLanguage.Description
	, dbClassificationPageSectionLanguage.MouseOver
	, dbClassificationPageSectionLanguage.MenuName
FROM dbClassificationPageSectionLanguage
JOIN dbClassificationPageSection 
	ON dbClassificationPageSectionLanguage.PageSectionId = dbClassificationPageSection.Id
WHERE dbClassificationPageSectionLanguage.LanguageId = @LanguageId
	AND dbClassificationPageSection.ClassificationPageId = @PId
ORDER BY DbClassificationPageSectionLanguage.Name
