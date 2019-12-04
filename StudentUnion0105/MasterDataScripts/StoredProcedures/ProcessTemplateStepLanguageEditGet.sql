CREATE PROCEDURE ProcessTemplateStepLanguageEditGet (@LId int)
AS
SELECT
	dbProcessTemplateStep.Id OId
	, Creator.UserName Creator
	, dbProcessTemplateStepLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbProcessTemplateStepLanguage.ModifiedDate
	, dbProcessTemplateStepLanguage.Id LId
	, ISNULL(dbProcessTemplateStepLanguage.Name,'') Name
	, ISNULL(dbProcessTemplateStepLanguage.Description,'') Description
	, ISNULL(dbProcessTemplateStepLanguage.MouseOver,'') MouseOver
	, ISNULL(dbProcessTemplateStepLanguage.MenuName,'') MenuName
	, ISNULL(dbLanguage.LanguageName,'') Language
	, dbProcessTemplateStep.ProcessTemplateId PId
FROM dbProcessTemplateStepLanguage
JOIN dbProcessTemplateStep
	ON dbProcessTemplateStep.Id = dbProcessTemplateStepLanguage.StepId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbProcessTemplateStepLanguage.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbProcessTemplateStepLanguage.ModifierId) = Modifier.Id
JOIN dbLanguage
	ON dbLanguage.Id = dbClassificationLanguage.LanguageId
WHERE dbProcessTemplateStepLanguage.Id=@LId

