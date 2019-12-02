CREATE PROCEDURE GetProcessTemplateFlowConditionCreateGetFields (@LanguageId Int, @Id int)
AS
SELECT dbProcessTemplateFieldLanguage.ProcessTemplateFieldId Id
	, dbProcessTemplateFieldLanguage.Name
FROM dbProcessTemplateField
JOIN dbProcessTemplateFieldLanguage
	ON dbProcessTemplateField.Id = dbProcessTemplateFieldLanguage.ProcessTemplateFieldId
JOIN dbProcessTemplateFlow
	ON dbProcessTemplateFlow.ProcessTemplateId = dbProcessTemplateField.ProcessTemplateId
WHERE dbProcessTemplateField.ProcessTemplateId = @Id
	AND dbProcessTemplateFieldLanguage.LanguageId = @LanguageId


