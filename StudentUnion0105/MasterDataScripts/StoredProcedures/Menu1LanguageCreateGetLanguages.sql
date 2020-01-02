CREATE PROCEDURE Menu1LanguageCreateGetLanguages (@OId int)
AS 
SELECT 
	dbLanguage.Id
	, dbLanguage.LanguageName Name
FROM dbLanguage
WHERE dbLanguage.Id NOT IN (SELECT LanguageId FROM dbMenu1Language WHERE Menu1Id = @OId)
AND dbLanguage.Active = 1
ORDER BY dbLanguage.LanguageName

