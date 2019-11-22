CREATE PROCEDURE PageLanguageIndexGet (@Id int)
AS
SELECT 
dbLanguage.LanguageName
	, dbPageLanguage.Id LId
	, dbPageLanguage.Name
	, dbPageLanguage.Description
	, dbPageLanguage.MouseOver
	, dbPageLanguage.MenuName
	, dbPageLanguage.PageId OId
	, 0 PId
FROM dbPageLanguage
JOIN dbLanguage 
	ON dbPageLanguage.LanguageId = dbLanguage.Id
WHERE dbPageLanguage.PageId = @Id
ORDER BY dbLanguage.LanguageName
