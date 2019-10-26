CREATE PROCEDURE ProcessTemplateFlowConditionEditGet (@LanguageId int, @Id int)
AS
SELECT
	dbProcessTemplateFlowCondition.Id 
	, dbProcessTemplateFlowCondition.ComparisonOperator
	, dbProcessTemplateFlowCondition.ConditionCharacter
	, dbProcessTemplateFlowCondition.ProcessTemplateConditionTypeId
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
	ON dbProcessTemplateFlowConditionLanguage.FlowConditionId = dbProcessTemplateFlowCondition.Id
JOIN dbProcessTemplateFlow
	ON dbProcessTemplateFlow.Id = dbProcessTemplateFlowCondition.ProcessTemplateFlowId
JOIN dbProcessTemplate
	ON dbProcessTemplate.Id = dbProcessTemplateFlow.ProcessTemplateId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbProcessTemplate.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbProcessTemplate.ModifierId) = Modifier.Id
WHERE dbProcessTemplateFlowConditionLanguage.LanguageId = @LanguageId
	AND dbProcessTemplateFlowCondition.Id = @Id

