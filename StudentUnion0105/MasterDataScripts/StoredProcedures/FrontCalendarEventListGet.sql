CREATE PROCEDURE FrontCalendarEventListGet (@Month int, @Year int)
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
FROM DbProcess
JOIN DbProcessField AllFields
	ON AllFields.ProcessId = DbProcess.Id
JOIN DbProcessTemplate
	ON DbProcessTemplate.Id = DbProcess.ProcessTemplateId
JOIN DbProcessTemplateField AllTemplate
	ON AllFields.ProcessTemplateFieldId = AllTemplate.Id
JOIN DbProcessField DateField
	ON DbProcess.Id = DateField.ProcessId
JOIN DbProcessTemplateField DateTemplateField
	ON DateField.ProcessTemplateFieldId = DateTemplateField.Id
JOIN DbProcessTemplateStep
	ON DbProcess.StepId = DbProcessTemplateStep.Id
WHERE DbProcessTemplate.ShowInEventCalendar = 1
	AND DateTemplateField.ProcessTemplateFieldTypeId IN (3,4,5,6)
	AND AllTemplate.ProcessTemplateFieldTypeId NOT IN (3,4,5,6)
	AND MONTH(DateField.DateTimeValue) = @Month
	AND YEAR(DateField.DateTimeValue) = @Year
ORDER BY DateField.DateTimeValue
