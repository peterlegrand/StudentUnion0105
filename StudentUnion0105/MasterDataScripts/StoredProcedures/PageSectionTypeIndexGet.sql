CREATE PROCEDURE PageSectionTypeIndexGet (@LanguageId int)
AS
SELECT 
	dbPageSectionTypeLanguage.Id
	, ISNULL(dbPageSectionTypeLanguage.Name,'') Name
	, ISNULL(dbPageSectionTypeLanguage.Description,'') Description
	, ISNULL(dbPageSectionTypeLanguage.MouseOver,'') MouseOver
	, ISNULL(dbPageSectionTypeLanguage.MenuName,'') MenuName
FROM dbPageSectionTypeLanguage
WHERE dbPageSectionTypeLanguage.LanguageId = @LanguageId
ORDER BY dbPageSectionTypeLanguage.Name