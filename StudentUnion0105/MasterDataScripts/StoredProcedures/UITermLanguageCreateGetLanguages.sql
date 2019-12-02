CREATE PROCEDURE UITermLanguageCreateGetLanguages (@Id int)
AS
SELECT 
	dbLanguage.Id
	, dbLanguage.LanguageName Name
FROM dbLanguage
WHERE dbLanguage.Id Not in (Select LanguageId FROM dbUITermLanguage WHERE TermId = @Id)
AND dbLanguage.Active = 1
ORDER BY dbLanguage.LanguageName
