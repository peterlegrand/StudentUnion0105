CREATE PROCEDURE ProcessTemplateLanguageIndexGet (@Id int)
AS
SELECT 
dbLanguage.LanguageName
	, dbProcessTemplateLanguage.Id LId
	, dbProcessTemplateLanguage.Name
	, dbProcessTemplateLanguage.Description
	, dbProcessTemplateLanguage.MouseOver
	, dbProcessTemplateLanguage.MenuName
	, dbProcessTemplateLanguage.ProcessTemplateId OId
	, 0 PId
FROM dbProcessTemplateLanguage
JOIN dbLanguage 
	ON dbProcessTemplateLanguage.LanguageId = dbLanguage.Id
WHERE dbProcessTemplateLanguage.ProcessTemplateId = @Id
ORDER BY dbLanguage.LanguageName
