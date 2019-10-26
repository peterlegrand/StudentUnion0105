CREATE PROCEDURE PageLanguageIndexGet (@Id int)
AS
SELECT 
dbLanguage.LanguageName
	, dbPageLanguage.Id
	, dbPageLanguage.Name
	, dbPageLanguage.Description
	, dbPageLanguage.MouseOver
	, dbPageLanguage.MenuName
FROM dbPageLanguage
JOIN dbLanguage 
	ON dbPageLanguage.LanguageId = dbLanguage.Id
WHERE dbPageLanguage.PageId = @Id
ORDER BY dbLanguage.LanguageName
