CREATE PROCEDURE LanguageSelectActive 
AS  
SELECT  
dbLanguage.Id 
, ISNULL(dbLanguage.LanguageName,'') Name 
FROM dbLanguage 
WHERE dbLanguage.Active = 1
ORDER BY dbLanguage.LanguageName 
