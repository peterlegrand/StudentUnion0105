CREATE PROCEDURE FrontProcessToDoEditGet (@LanguageId int, @PId int) AS 
SELECT  
	DbProcess.Id PId
	, ISNULL(DbProcessField.Id, 0) FId
	, DbProcessTemplateField.Id PTFId
	, DbProcessTemplateStepField.StatusId
	, DbProcessTemplateFieldLanguage.Name
	, DbProcessTemplateFieldLanguage.MouseOver
	, ISNULL(DbProcessField.StringValue, '') StringValue
	, ISNULL(DbProcessField.IntValue, '') IntValue
	, ISNULL(DbProcessField.DateTimeValue, getdate()) DateTimeValue
	, DbProcessTemplateStepField.Sequence
	, DbProcessTemplateField.FieldDataTypeId
	, DbProcessTemplateField.FieldMasterListId
FROM DbProcess
JOIN DbProcessTemplateStepField
	ON dbprocess.StepId =  DbProcessTemplateStepField.StepId
JOIN DbProcessTemplateField 
	ON DbProcessTemplateField.Id =  DbProcessTemplateStepField.FieldId
LEFT JOIN DbProcessField
	ON dbprocess.Id = DbProcessField.ProcessId
	AND DbProcessField.ProcessTemplateFieldId = dbprocesstemplatefield.Id
JOIN DbProcessTemplateFieldLanguage
	ON dbprocesstemplatefield.Id = DbProcessTemplateFieldLanguage.ProcessTemplateFieldId
WHERE DbProcessTemplateFieldLanguage.LanguageId = @LanguageId
	AND DbProcess.Id = @PId
ORDER BY Sequence
