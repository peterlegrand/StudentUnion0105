CREATE PROCEDURE UserRelationTypeLanguageCreateGetLanguages (@OId int)
AS 
SELECT 
	dbLanguage.Id
	, dbLanguage.LanguageName Name
FROM dbLanguage
WHERE dbLanguage.Id NOT IN (SELECT LanguageId FROM dbUserRelationTypeLanguage WHERE TypeId = @OId)
AND dbLanguage.Active = 1
ORDER BY dbLanguage.LanguageName

