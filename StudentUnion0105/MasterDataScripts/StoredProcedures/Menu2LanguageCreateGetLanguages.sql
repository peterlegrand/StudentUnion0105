CREATE PROCEDURE Menu2LanguageCreateGetLanguages (@OId int)
AS 
SELECT 
	dbLanguage.Id
	, dbLanguage.LanguageName Name
FROM dbLanguage
WHERE dbLanguage.Id NOT IN (SELECT LanguageId FROM dbMenu2Language WHERE Menu2Id = @OId)
AND dbLanguage.Active = 1
ORDER BY dbLanguage.LanguageName

