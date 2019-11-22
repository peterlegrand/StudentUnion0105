CREATE PROCEDURE ProcessTemplateFlowConditionDeleteGet (@LanguageId int, @Id int)
AS
SELECT
	dbProcessTemplateFlowCondition.Id 
	, dbComparison.Name ComparisonOperator
	, dbProcessTemplateFlowConditionType.Name FlowType
	, dbProcessTemplateFlowCondition.ProcessTemplateFlowConditionDate
	, dbProcessTemplateFlowCondition.ProcessTemplateFlowConditionInt
	, dbProcessTemplateFlowCondition.ProcessTemplateFlowConditionString
	, Creator.UserName Creator
	, dbProcessTemplate.CreatedDate
	, Modifier.UserName Modifier
	, dbProcessTemplate.ModifiedDate
	, dbProcessTemplateFlowConditionLanguage.Id LId
	, dbProcessTemplateFlowConditionLanguage.Name
	, dbProcessTemplateFlowConditionLanguage.Description
	, dbProcessTemplateFlowConditionLanguage.MouseOver
	, dbProcessTemplateFlowConditionLanguage.MenuName
FROM dbProcessTemplateFlowConditionLanguage
JOIN dbProcessTemplateFlowCondition
	ON dbProcessTemplateFlowCondition.Id = dbProcessTemplateFlowConditionLanguage.FlowConditionId
JOIN dbProcessTemplateFlow
	ON dbProcessTemplateFlow.Id = dbProcessTemplateFlowCondition.ProcessTemplateFlowId
JOIN dbProcessTemplate
	ON dbProcessTemplate.Id = dbProcessTemplateFlow.ProcessTemplateId
JOIN dbProcessTemplateFlowConditionType
	ON dbProcessTemplateFlowConditionType.Id = dbProcessTemplateFlowCondition.ProcessTemplateConditionTypeId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbProcessTemplate.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbProcessTemplate.ModifierId) = Modifier.Id
JOIN dbComparison
	ON dbProcessTemplateFlowCondition.ComparisonOperatorId = dbComparison.Id
WHERE dbProcessTemplateFlowConditionLanguage.LanguageId = @LanguageId
	AND dbProcessTemplateFlowCondition.Id = @Id

