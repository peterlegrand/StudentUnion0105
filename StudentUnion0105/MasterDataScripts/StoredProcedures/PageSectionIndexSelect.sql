CREATE PROCEDURE PageSectionIndexSelect (@LanguageId int)
AS 
SELECT dbPageSection.Id
	, dbPageSectionLanguage.LanguageId
	, dbPageSectionLanguage.Name
	, dbPageSectionLanguage.MouseOver
	, dbPageSectionLanguage.MenuName
	, dbPageSectionTypeLanguage.Name Type
FROM dbPageSection
JOIN dbPageSectionLanguage
	ON dbPageSection.Id = dbPageSectionLanguage.PageSectionId
JOIN dbPageSectionTypeLanguage
	ON dbPageSectionTypeLanguage.PageSectionTypeId = dbPageSection.PageSectionTypeId
WHERE dbPageSectionLanguage.LanguageId = @LanguageId
	AND dbPageSectionTypeLanguage.LanguageId = @LanguageId
ORDER BY 
dbPageSection.Sequence


