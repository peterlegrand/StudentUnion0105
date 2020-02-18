CREATE PROCEDURE ProcessTemplateList (@LanguageId int) 
AS
SELECT 
	DbProcessTemplateLanguage.Id
	, DbProcessTemplateLanguage.Name 
FROM DbProcessTemplateLanguage 
WHERE DbProcessTemplateLanguage.LanguageId = @LanguageId
ORDER BY DbProcessTemplateLanguage.Name