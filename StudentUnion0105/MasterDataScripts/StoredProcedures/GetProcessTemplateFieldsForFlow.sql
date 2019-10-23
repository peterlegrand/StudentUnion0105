
CREATE PROCEDURE [dbo].[GetProcessTemplateFieldsForFlow] (@LanguageId Int, @FlowId int)
AS
SELECT dbProcessTemplateFieldLanguage.ProcessTemplateFieldId
	, dbProcessTemplateFieldLanguage.Name
FROM dbProcessTemplateField
JOIN dbProcessTemplateFieldLanguage
	ON dbProcessTemplateField.Id = dbProcessTemplateFieldLanguage.ProcessTemplateFieldId
JOIN dbProcessTemplateFlow
	ON dbProcessTemplateFlow.ProcessTemplateId = dbProcessTemplateField.ProcessTemplateId
WHERE dbProcessTemplateField.ProcessTemplateId = @FlowId
	AND dbProcessTemplateFieldLanguage.LanguageId = @LanguageId


