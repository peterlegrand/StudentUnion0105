CREATE PROCEDURE ProcessTemplateStepIndexSelect (@LanguageId int)
AS 
SELECT dbProcessTemplateStep.Id
	, dbProcessTemplateStepLanguage.LanguageId
	, dbProcessTemplateStep.ProcessTemplateId
	, dbProcessTemplateStepLanguage.Name
	, dbProcessTemplateStepLanguage.MouseOver
	, dbProcessTemplateStepLanguage.MenuName
FROM dbProcessTemplateStep
JOIN dbProcessTemplateStepLanguage
	ON dbProcessTemplateStep.Id = dbProcessTemplateStepLanguage.StepId
WHERE dbProcessTemplateStepLanguage.LanguageId = @LanguageId
ORDER BY 
dbProcessTemplateStepLanguage.Name


