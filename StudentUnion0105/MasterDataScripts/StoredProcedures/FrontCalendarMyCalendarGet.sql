CREATE PROCEDURE FrontCalendarMyCalendarGet (@CurrentUserId nvarchar(50), @Month int, @Year int)
AS
SELECT 
	DbProcess.Id ProcessId
	, DbProcess.StepId
	, AllFields.Id ProcessFieldId
	, AllFields.DateTimeValue
	, AllFields.IntValue
	, AllFields.StringValue
	, AllFields.ProcessTemplateFieldId
	, AllTemplate.ProcessTemplateFieldTypeId
	, DateField.DateTimeValue MainDate
	, DbProcessTemplateStep.ProcessTemplateStepTypeId
FROM DbProcessField UserField 
JOIN DbProcess
	ON UserField.ProcessId = DbProcess.Id
JOIN DbProcessField AllFields
	ON AllFields.ProcessId = DbProcess.Id
JOIN DbProcessTemplateField UserTemplate
	ON UserField.ProcessTemplateFieldId = UserTemplate.Id
JOIN DbProcessTemplate
	ON DbProcessTemplate.Id = DbProcess.ProcessTemplateId
JOIN DbProcessTemplateField AllTemplate
	ON AllFields.ProcessTemplateFieldId = AllTemplate.Id
JOIN DbProcessField DateField
	ON DateField.ProcessId = DbProcess.Id
JOIN DbProcessTemplateField DateTemplateField
	ON DateField.ProcessTemplateFieldId = DateTemplateField.Id
JOIN DbProcessTemplateStep
	ON DbProcess.StepId = DbProcessTemplateStep.Id
WHERE UserField.StringValue = @CurrentUserId
	AND UserTemplate.ProcessTemplateFieldTypeId = 11
	AND AllFields.ProcessTemplateFieldId <> UserField.ProcessTemplateFieldId
	AND DbProcessTemplate.ShowInPersonalCalendar = 1
	AND DateTemplateField.ProcessTemplateFieldTypeId IN (3,4,5,6)
	AND AllTemplate.ProcessTemplateFieldTypeId NOT  IN (3,4,5,6)
	AND MONTH(DateField.DateTimeValue) = @Month
	AND YEAR(DateField.DateTimeValue) = @Year
ORDER BY DateField.DateTimeValue
	