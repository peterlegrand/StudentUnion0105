CREATE PROCEDURE ProcessTemplateFlowConditionEditGet (@LanguageId int, @Id int)
AS
SELECT
	dbProcessTemplateFlowCondition.Id OId 
	, dbProcessTemplateFlowConditionLanguage.Id LId
	, dbProcessTemplateFlowConditionLanguage.LanguageId
	, dbProcessTemplateFlowCondition.ProcessTemplateConditionTypeId
	, ISNULL(dbProcessTemplateFlowCondition.ComparisonOperatorId, 0) ComparisonOperatorId
	, ISNULL(dbProcessTemplateFlowCondition.ProcessTemplateFieldId, 0) ProcessTemplateFieldId
	, ISNULL(dbProcessTemplateFlowCondition.DataTypeId, 0) DataTypeId
	, ISNULL(dbProcessTemplateFlowCondition.ProcessTemplateFlowConditionDate, '1900-01-01') ProcessTemplateFlowConditionDate
	, ISNULL(dbProcessTemplateFlowCondition.ProcessTemplateFlowConditionInt, 0) ProcessTemplateFlowConditionInt 
	, ISNULL(dbProcessTemplateFlowCondition.ProcessTemplateFlowConditionString, '') ProcessTemplateFlowConditionString
	, Creator.UserName Creator
	, dbProcessTemplate.CreatedDate
	, Modifier.UserName Modifier
	, dbProcessTemplate.ModifiedDate
	, ISNULL(dbProcessTemplateFlowConditionLanguage.Name, '') Name
	, ISNULL(dbProcessTemplateFlowConditionLanguage.Description, '')  Description
	, ISNULL(dbProcessTemplateFlowConditionLanguage.MouseOver, '') MouseOver
	, ISNULL(dbProcessTemplateFlowConditionLanguage.MenuName, '') MenuName
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

