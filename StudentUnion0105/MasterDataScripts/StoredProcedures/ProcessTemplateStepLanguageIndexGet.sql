CREATE PROCEDURE ProcessTemplateStepLanguageIndexGet (@Id int)
AS
SELECT 
dbLanguage.LanguageName
	, dbProcessTemplateStepLanguage.Id
	, dbProcessTemplateStepLanguage.Name
	, dbProcessTemplateStepLanguage.Description
	, dbProcessTemplateStepLanguage.MouseOver
	, dbProcessTemplateStepLanguage.MenuName
FROM dbProcessTemplateStepLanguage
JOIN dbLanguage 
	ON dbProcessTemplateStepLanguage.LanguageId = dbLanguage.Id
WHERE dbProcessTemplateStepLanguage.StepId = @Id
ORDER BY dbLanguage.LanguageName
