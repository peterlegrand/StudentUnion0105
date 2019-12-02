CREATE PROCEDURE PageSectionTypeLanguageIndexGet (@OId int)
AS
SELECT 
	dbPageSectionTypeLanguage.Id LId
	, dbPageSectionTypeLanguage.PageSectionTypeId OId
	, 0 PId
	, ISNULL(dbPageSectionTypeLanguage.Name,'') Name
	, ISNULL(dbPageSectionTypeLanguage.Description,'') Description
	, ISNULL(dbPageSectionTypeLanguage.MouseOver,'') MouseOver
	, ISNULL(dbPageSectionTypeLanguage.MenuName,'') MenuName
	, dbLanguage.Id LanguageId
	, ISNULL(dbLanguage.LanguageName,'') LanguageName
FROM dbPageSectionTypeLanguage
JOIN dbLanguage 
	ON dbPageSectionTypeLanguage.LanguageId = dbLanguage.Id
WHERE dbPageSectionTypeLanguage.PageSectionTypeId = @OId
ORDER BY dbLanguage.LanguageName
