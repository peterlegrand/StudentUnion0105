CREATE PROCEDURE ProcessTemplateFieldLanguageIndexGet (@Id int)
AS
SELECT 
dbLanguage.LanguageName
	, dbProcessTemplateFieldLanguage.Id
	, dbProcessTemplateFieldLanguage.Name
	, dbProcessTemplateFieldLanguage.Description
	, dbProcessTemplateFieldLanguage.MouseOver
	, dbProcessTemplateFieldLanguage.MenuName
FROM dbProcessTemplateFieldLanguage
JOIN dbLanguage 
	ON dbProcessTemplateFieldLanguage.LanguageId = dbLanguage.Id
WHERE dbProcessTemplateFieldLanguage.ProcessTemplateFieldId = @Id
ORDER BY dbLanguage.LanguageName
