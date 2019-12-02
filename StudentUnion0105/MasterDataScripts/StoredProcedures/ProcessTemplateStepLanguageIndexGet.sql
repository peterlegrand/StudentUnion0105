CREATE PROCEDURE ProcessTemplateStepLanguageIndexGet (@OId int)
AS
SELECT 
	dbProcessTemplateStepLanguage.Id LId
	, dbProcessTemplateStepLanguage.StepId OId
	, dbProcessTemplateStep.ProcessTemplateId PId
	, ISNULL(dbProcessTemplateStepLanguage.Name,'') Name
	, ISNULL(dbProcessTemplateStepLanguage.Description,'') Description
	, ISNULL(dbProcessTemplateStepLanguage.MouseOver,'') MouseOver
	, ISNULL(dbProcessTemplateStepLanguage.MenuName,'') MenuName
	, dbLanguage.Id LanguageId
	, ISNULL(dbLanguage.LanguageName,'') LanguageName
FROM dbProcessTemplateStepLanguage
JOIN dbLanguage 
	ON dbProcessTemplateStepLanguage.LanguageId = dbLanguage.Id
JOIN dbProcessTemplateStep
	ON dbProcessTemplateStep.Id = dbProcessTemplateStepLanguage.StepId
WHERE dbProcessTemplateStepLanguage.StepId = @OId
ORDER BY dbLanguage.LanguageName
