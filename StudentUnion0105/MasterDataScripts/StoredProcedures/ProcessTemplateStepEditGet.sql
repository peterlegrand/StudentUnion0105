CREATE PROCEDURE ProcessTemplateStepEditGet (@LanguageId int, @Id int)
AS
SELECT
	dbProcessTemplateStep.Id 
	, Creator.UserName Creator
	, dbProcessTemplate.CreatedDate
	, Modifier.UserName Modifier
	, dbProcessTemplate.ModifiedDate
	, dbProcessTemplateStepLanguage.Id LId
	, dbProcessTemplateStepLanguage.Name
	, dbProcessTemplateStepLanguage.Description
	, dbProcessTemplateStepLanguage.MouseOver
	, dbProcessTemplateStepLanguage.MenuName
FROM dbProcessTemplateStepLanguage
JOIN dbProcessTemplateStep 
	ON dbProcessTemplateStepLanguage.StepId = dbProcessTemplateStep.Id
JOIN dbProcessTemplate
	ON dbProcessTemplate.Id = dbProcessTemplateStep.ProcessTemplateId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbProcessTemplate.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbProcessTemplate.ModifierId) = Modifier.Id
WHERE dbProcessTemplateStepLanguage.LanguageId = @LanguageId
	AND dbProcessTemplateStep.Id = @Id

