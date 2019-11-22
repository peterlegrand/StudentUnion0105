CREATE PROCEDURE FrontProcessIndexGetTemplate (@LanguageId int, @PId int)
AS
SELECT 
	dbProcessTemplate.Id OId
	, dbProcessTemplate.ProcessTemplateGroupId PId
	, dbProcessTemplateLanguage.Name
	, dbProcessTemplateLanguage.Description 
FROM dbProcessTemplateFlow 
JOIN dbProcessTemplate
	ON dbProcessTemplateFlow.ProcessTemplateId = dbProcessTemplate.Id
JOIN dbProcessTemplateLanguage
	ON dbProcessTemplate.Id = dbProcessTemplateLanguage.ProcessTemplateId
WHERE dbProcessTemplateFlow.ProcessTemplateFromStepId = 0
	AND dbProcessTemplate.ProcessTemplateGroupId = @PId
	AND dbProcessTemplateLanguage.LanguageId = @LanguageId
