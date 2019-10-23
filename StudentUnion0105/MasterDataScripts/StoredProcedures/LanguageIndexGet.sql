CREATE PROCEDURE LanguageIndexGet
AS
SELECT 
	dbLanguage.Id
	, dbLanguage.LanguageName
	, dbLanguage.ForeignName
	, dbLanguage.ISO6391
	, dbLanguage.ISO6392
	, dbLanguage.Active
FROM dbLanguage
ORDER BY dbLanguage.LanguageName