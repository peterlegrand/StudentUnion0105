CREATE PROCEDURE ProjectIndexGet (@LanguageId int)
AS
SELECT 
	dbProjectLanguage.Id
	, dbProjectLanguage.Name
	, dbProjectLanguage.Description
	, dbProjectLanguage.MouseOver
	, dbProjectLanguage.MenuName
FROM dbProjectLanguage
WHERE dbProjectLanguage.LanguageId = @LanguageId
ORDER BY dbProjectLanguage.Name
