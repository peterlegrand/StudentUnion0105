CREATE PROCEDURE FrontProcessCreateGetField (@LanguageId int, @PId int)
AS
SELECT 
	0 OId 
	, dbProcessTemplateField.ProcessTemplateId PId
	, dbProcessTemplateField.Id FieldId
	, dbProcessTemplateFieldLanguage.Name
	, dbProcessTemplateFieldLanguage.Description
	, dbProcessTemplateStepField.StatusId
	, dbProcessTemplateField.FieldDataTypeId DataTypeId
	, dbProcessTemplateField.FieldMasterListId MasterListId
	, '' StringValue
	, 0 IntValue
	, CAST('1900-01-01' as datetime) DateTimeValue
FROM dbProcessTemplateField
JOIN dbProcessTemplateFieldLanguage
	ON dbProcessTemplateField.Id = dbProcessTemplateFieldLanguage.ProcessTemplateFieldId
JOIN dbProcessTemplateStepField
	ON dbProcessTemplateStepField.FieldId = dbProcessTemplateField.Id
JOIN dbProcessTemplateStep
	ON dbProcessTemplateStep.Id = dbProcessTemplateStepField.StepId
JOIN dbProcessTemplateFlow
	ON dbProcessTemplateFlow.ProcessTemplateToStepId = dbProcessTemplateStep.Id
JOIN dbDataType
	ON dbDataType.Id = dbProcessTemplateField.FieldDataTypeId
WHERE dbProcessTemplateFlow.ProcessTemplateFromStepId = 0
AND dbProcessTemplateField.ProcessTemplateId = @PId
AND dbProcessTemplateFieldLanguage.LanguageId = 41
AND dbProcessTemplateStepField.StatusId <> 1
ORDER BY dbProcessTemplateStepField.Sequence

