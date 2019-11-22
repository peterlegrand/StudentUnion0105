CREATE PROCEDURE ProcessTemplateFieldLanguageIndexGet (@Id int)
AS
SELECT 
dbLanguage.LanguageName
	, dbProcessTemplateFieldLanguage.Id LId
	, dbProcessTemplateFieldLanguage.Name
	, dbProcessTemplateFieldLanguage.Description
	, dbProcessTemplateFieldLanguage.MouseOver
	, dbProcessTemplateFieldLanguage.MenuName
	, dbProcessTemplateFieldLanguage.ProcessTemplateFieldId OId
	, dbProcessTemplateField.ProcessTemplateId PId
FROM dbProcessTemplateFieldLanguage
JOIN dbLanguage 
	ON dbProcessTemplateFieldLanguage.LanguageId = dbLanguage.Id
JOIN dbProcessTemplateField
	ON dbProcessTemplateField.Id = dbProcessTemplateFieldLanguage.ProcessTemplateFieldId
WHERE dbProcessTemplateFieldLanguage.ProcessTemplateFieldId = @Id
ORDER BY dbLanguage.LanguageName
