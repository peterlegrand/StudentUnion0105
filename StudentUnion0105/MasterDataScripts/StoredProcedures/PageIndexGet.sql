CREATE PROCEDURE PageIndexGet (@LanguageId int)
AS
SELECT 
	dbPageLanguage.Id
	, dbPageLanguage.Name
	, dbPageLanguage.Description
	, dbPageLanguage.MouseOver
	, dbPageLanguage.MenuName
FROM dbPageLanguage
WHERE dbPageLanguage.LanguageId = @LanguageId
ORDER BY dbPageLanguage.Name