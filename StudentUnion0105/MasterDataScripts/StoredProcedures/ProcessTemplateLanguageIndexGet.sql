CREATE PROCEDURE ProcessTemplateLanguageIndexGet (@Id int)
AS
SELECT 
dbLanguage.LanguageName
	, dbProcessTemplateLanguage.Id
	, dbProcessTemplateLanguage.Name
	, dbProcessTemplateLanguage.Description
	, dbProcessTemplateLanguage.MouseOver
	, dbProcessTemplateLanguage.MenuName
FROM dbProcessTemplateLanguage
JOIN dbLanguage 
	ON dbProcessTemplateLanguage.LanguageId = dbLanguage.Id
WHERE dbProcessTemplateLanguage.ProcessTemplateId = @Id
ORDER BY dbLanguage.LanguageName
