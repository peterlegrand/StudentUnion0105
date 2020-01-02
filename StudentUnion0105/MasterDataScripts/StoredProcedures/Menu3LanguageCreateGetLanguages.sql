CREATE PROCEDURE Menu3LanguageCreateGetLanguages (@OId int)
AS 
SELECT 
	dbLanguage.Id
	, dbLanguage.LanguageName Name
FROM dbLanguage
WHERE dbLanguage.Id NOT IN (SELECT LanguageId FROM dbMenu3Language WHERE Menu3Id = @OId)
AND dbLanguage.Active = 1
ORDER BY dbLanguage.LanguageName

