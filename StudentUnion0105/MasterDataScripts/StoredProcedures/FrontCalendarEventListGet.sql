CREATE PROCEDURE FrontCalendarEventListGet (@CurrentUserId nvarchar(50))
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
FROM DbProcessField UserField 
JOIN DbProcess
	ON UserField.ProcessId = DbProcess.Id
JOIN DbProcessField AllFields
	ON AllFields.ProcessId = DbProcess.Id
JOIN DbProcessTemplate
	ON DbProcessTemplate.Id = DbProcess.ProcessTemplateId
JOIN DbProcessTemplateField AllTemplate
	ON AllFields.ProcessTemplateFieldId = AllTemplate.Id
WHERE DbProcessTemplate.ShowInEventCalendar = 1
	