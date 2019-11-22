CREATE PROCEDURE ProcessTemplateStepLanguageIndexGet (@Id int)
AS
SELECT 
dbLanguage.LanguageName
	, dbProcessTemplateStepLanguage.Id LId
	, dbProcessTemplateStepLanguage.Name
	, dbProcessTemplateStepLanguage.Description
	, dbProcessTemplateStepLanguage.MouseOver
	, dbProcessTemplateStepLanguage.MenuName
	, dbProcessTemplateStepLanguage.StepId OId
	, dbProcessTemplateStep.ProcessTemplateId PId
FROM dbProcessTemplateStepLanguage
JOIN dbLanguage 
	ON dbProcessTemplateStepLanguage.LanguageId = dbLanguage.Id
JOIN dbProcessTemplateStep
	ON dbProcessTemplateStep.Id = dbProcessTemplateStepLanguage.StepId
WHERE dbProcessTemplateStepLanguage.StepId = @Id
ORDER BY dbLanguage.LanguageName
