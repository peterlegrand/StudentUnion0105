CREATE PROCEDURE FrontProcessCreateGet (@LanguageId int)
AS
SELECT
	0 OId
	, dbProcessTemplate.Id PId
	, dbProcessTemplateFlow.ProcessTemplateToStepId StepId
	, dbProcessTemplateLanguage.Name
	, dbProcessTemplateLanguage.Description
FROM dbProcessTemplate
JOIN dbProcessTemplateFlow
	ON dbProcessTemplate.Id = dbProcessTemplateFlow.ProcessTemplateId
JOIN dbProcessTemplateLanguage
	ON dbProcessTemplate.Id = dbProcessTemplateLanguage.ProcessTemplateId
WHERE dbProcessTemplateFlow.ProcessTemplateFromStepId = 0
	AND dbProcessTemplateLanguage.LanguageId = @LanguageId