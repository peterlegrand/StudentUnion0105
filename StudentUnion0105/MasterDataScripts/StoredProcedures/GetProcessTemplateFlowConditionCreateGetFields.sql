CREATE PROCEDURE GetProcessTemplateFlowConditionCreateGetFields (@LanguageId Int, @FlowId int)
AS
SELECT dbProcessTemplateFieldLanguage.ProcessTemplateFieldId Id
	, dbProcessTemplateFieldLanguage.Name
FROM dbProcessTemplateField
JOIN dbProcessTemplateFieldLanguage
	ON dbProcessTemplateField.Id = dbProcessTemplateFieldLanguage.ProcessTemplateFieldId
JOIN dbProcessTemplateFlow
	ON dbProcessTemplateFlow.ProcessTemplateId = dbProcessTemplateField.ProcessTemplateId
WHERE dbProcessTemplateField.ProcessTemplateId = @FlowId
	AND dbProcessTemplateFieldLanguage.LanguageId = @LanguageId


