CREATE PROCEDURE FrontProcessCreateGetField (@CurrentUser nvarchar(50), @Id int)
AS
DECLARE @SecurityLevel int;
DECLARE @LanguageId int;
SELECT @LanguageId = AspNetUsers.DefaultLanguageId , @SecurityLevel = SecurityLevel FROM AspNetUsers WHERE Id = @CurrentUser;
SELECT 
	OId
	, PId
	, FieldId
	, Name
	, Description
	, StatusId
	, ProcessTemplateFieldTypeId
	, StringValue
	, IntValue
	, DateTimeValue
FROM (
SELECT DISTINCT 
	0 OId
	, DbProcessTemplateFlow.ProcessTemplateId PId
	, DbProcessTemplateFieldLanguage.ProcessTemplateFieldId FieldId
	, DbProcessTemplateFieldLanguage.Name
	, DbProcessTemplateFieldLanguage.Description
	, DbProcessTemplateStepField.StatusId
	, DbProcessTemplateField.ProcessTemplateFieldTypeId
	, '' StringValue
	, 0 IntValue
	, CAST('1900-01-01' as datetime) DateTimeValue
	, DbProcessTemplateStepField.Sequence
FROM DbProcessTemplateFlow 
JOIN DbProcessTemplateFlowCondition
	ON DbProcessTemplateFlow.Id = DbProcessTemplateFlowCondition.ProcessTemplateFlowId
JOIN DbProcessTemplateField
	ON DbProcessTemplateFlow.ProcessTemplateId = DbProcessTemplateField.ProcessTemplateId
JOIN DbProcessTemplateStep
	ON DbProcessTemplateFlow.ProcessTemplateId = DbProcessTemplateStep.ProcessTemplateId
	AND DbProcessTemplateFlow.ProcessTemplateToStepId = DbProcessTemplateStep.Id
JOIN DbProcessTemplateStepField
	ON DbProcessTemplateStep.Id = DbProcessTemplateStepField.StepId
	AND DbProcessTemplateField.Id = DbProcessTemplateStepField.FieldId
JOIN DbProcessTemplateFieldLanguage
	ON DbProcessTemplateField.Id = DbProcessTemplateFieldLanguage.ProcessTemplateFieldId 
WHERE ProcessTemplateFromStepId = 0
	AND DbProcessTemplateFlowCondition.ProcessTemplateConditionTypeId = 15
	AND DbProcessTemplateFlowCondition.ProcessTemplateFlowConditionInt <= @SecurityLevel
	AND DbProcessTemplateFieldLanguage.LanguageId = @LanguageId
	AND DbProcessTemplateStepField.StatusId <> 1
	AND DbProcessTemplateFlow.ProcessTemplateId = @Id
UNION ALL

SELECT DISTINCT 
	0 OId
	, DbProcessTemplateFlow.ProcessTemplateId PId
	, DbProcessTemplateFieldLanguage.ProcessTemplateFieldId FieldId
	, DbProcessTemplateFieldLanguage.Name
	, DbProcessTemplateFieldLanguage.Description
	, DbProcessTemplateStepField.StatusId
	, DbProcessTemplateField.ProcessTemplateFieldTypeId
	, '' StringValue
	, 0 IntValue
	, CAST('1900-01-01' as datetime) DateTimeValue
	, DbProcessTemplateStepField.Sequence
FROM DbProcessTemplateFlow
JOIN DbProcessTemplateField
	ON DbProcessTemplateFlow.ProcessTemplateId = DbProcessTemplateField.ProcessTemplateId
JOIN DbProcessTemplateStep
	ON DbProcessTemplateFlow.ProcessTemplateId = DbProcessTemplateStep.ProcessTemplateId
	AND DbProcessTemplateFlow.ProcessTemplateToStepId = DbProcessTemplateStep.Id
JOIN DbProcessTemplateStepField
	ON DbProcessTemplateStep.Id = DbProcessTemplateStepField.StepId
	AND DbProcessTemplateField.Id = DbProcessTemplateStepField.FieldId
JOIN DbProcessTemplateFieldLanguage
	ON DbProcessTemplateField.Id = DbProcessTemplateFieldLanguage.ProcessTemplateFieldId 
WHERE DbProcessTemplateFlow.Id NOT IN (
select DbProcessTemplateFlowCondition.ProcessTemplateFlowId from DbProcessTemplateFlowCondition WHERE DbProcessTemplateFlowCondition.ProcessTemplateConditionTypeId = 15
)
	AND DbProcessTemplateFlow.ProcessTemplateFromStepId = 0
	AND DbProcessTemplateFlow.ProcessTemplateId = @Id
	AND DbProcessTemplateStepField.StatusId <> 1

) FullResult
ORDER BY Sequence