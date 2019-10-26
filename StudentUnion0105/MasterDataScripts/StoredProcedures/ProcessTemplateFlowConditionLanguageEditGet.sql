CREATE PROCEDURE ProcessTemplateFlowConditionLanguageEditGet (@Id int)
AS
SELECT
	dbProcessTemplateFlowCondition.Id 
	, Creator.UserName Creator
	, dbProcessTemplateFlowConditionLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbProcessTemplateFlowConditionLanguage.ModifiedDate
	, dbProcessTemplateFlowConditionLanguage.Id LId
	, dbProcessTemplateFlowConditionLanguage.Name
	, dbProcessTemplateFlowConditionLanguage.Description
	, dbProcessTemplateFlowConditionLanguage.MouseOver
	, dbProcessTemplateFlowConditionLanguage.MenuName
FROM dbProcessTemplateFlowConditionLanguage
JOIN dbProcessTemplateFlowCondition
	ON dbProcessTemplateFlowCondition.Id = dbProcessTemplateFlowConditionLanguage.FlowConditionId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbProcessTemplateFlowConditionLanguage.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbProcessTemplateFlowConditionLanguage.ModifierId) = Modifier.Id
WHERE dbProcessTemplateFlowConditionLanguage.Id=@Id

