CREATE PROCEDURE ProcessTemplateFlowEditGet (@LanguageId int, @Id int)
AS
SELECT
	dbProcessTemplateFlow.Id 
	, dbProcessTemplateFlow.ProcessTemplateFromStepId
	, dbProcessTemplateFlow.ProcessTemplateToStepId
	, Creator.UserName Creator
	, dbProcessTemplate.CreatedDate
	, Modifier.UserName Modifier
	, dbProcessTemplate.ModifiedDate
	, dbProcessTemplateFlowLanguage.Id LId
	, dbProcessTemplateFlowLanguage.Name
	, dbProcessTemplateFlowLanguage.Description
	, dbProcessTemplateFlowLanguage.MouseOver
	, dbProcessTemplateFlowLanguage.MenuName
FROM dbProcessTemplateFlowLanguage
JOIN dbProcessTemplateFlow 
	ON dbProcessTemplateFlowLanguage.FlowId = dbProcessTemplateFlow.Id
JOIN dbProcessTemplate
	ON dbProcessTemplate.Id = dbProcessTemplateFlow.ProcessTemplateId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbProcessTemplate.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbProcessTemplate.ModifierId) = Modifier.Id
WHERE dbProcessTemplateFlowLanguage.LanguageId = @LanguageId
	AND dbProcessTemplateFlow.Id = @Id

