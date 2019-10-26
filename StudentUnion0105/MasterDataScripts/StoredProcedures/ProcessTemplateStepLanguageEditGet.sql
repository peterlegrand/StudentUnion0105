CREATE PROCEDURE ProcessTemplateStepLanguageEditGet (@Id int)
AS
SELECT
	dbProcessTemplateStep.Id 
	, Creator.UserName Creator
	, dbProcessTemplateStepLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbProcessTemplateStepLanguage.ModifiedDate
	, dbProcessTemplateStepLanguage.Id LId
	, dbProcessTemplateStepLanguage.Name
	, dbProcessTemplateStepLanguage.Description
	, dbProcessTemplateStepLanguage.MouseOver
	, dbProcessTemplateStepLanguage.MenuName
FROM dbProcessTemplateStepLanguage
JOIN dbProcessTemplateStep
	ON dbProcessTemplateStep.Id = dbProcessTemplateStepLanguage.StepId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbProcessTemplateStepLanguage.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbProcessTemplateStepLanguage.ModifierId) = Modifier.Id
WHERE dbProcessTemplateStepLanguage.Id=@Id

