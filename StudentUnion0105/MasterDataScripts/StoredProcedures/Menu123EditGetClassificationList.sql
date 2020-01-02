CREATE PROCEDURE Menu123EditGetClassificationList (@LanguageId int)
AS
SELECT
	dbClassificationLanguage.Id 
	, dbClassificationLanguage.Name
FROM dbClassificationLanguage
WHERE dbClassificationLanguage.LanguageId = @LanguageId
ORDER BY dbClassificationLanguage.Name

