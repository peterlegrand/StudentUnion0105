CREATE PROCEDURE ClassificationLanguageCreateGetLanguages (@OId int)
AS 
SELECT 
	dbLanguage.Id
	, dbLanguage.LanguageName Name
FROM dbLanguage
WHERE dbLanguage.Id NOT IN (SELECT LanguageId FROM dbClassificationLanguage WHERE ClassificationId = @OId)
AND dbLanguage.Active = 1
ORDER BY dbLanguage.LanguageName

