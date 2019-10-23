

CREATE PROCEDURE PageSectionIndexGet (@Id int, @LanguageId int)
AS
SELECT 
	dbPageSectionLanguage.Id
	, dbPageSectionLanguage.Name
	, dbPageSectionLanguage.Description
	, dbPageSectionLanguage.MouseOver
	, dbPageSectionLanguage.MenuName
FROM dbPageSectionLanguage
JOIN dbPageSection 
	ON dbPageSectionLanguage.PageSectionId = dbPageSection.Id
WHERE dbPageSectionLanguage.LanguageId = @LanguageId
	AND dbPageSection.PageId = @Id
ORDER BY dbPageSection.Sequence
