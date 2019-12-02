CREATE PROCEDURE FrontProcessIndexGetTemplateFlowCondition (@PId int)
AS
SELECT
	dbProcessTemplateFlowCondition.Id OId
	, dbProcessTemplateFlowCondition.ProcessTemplateConditionTypeId ConditionTypeId
	, ISNULL(dbProcessTemplateFlowCondition.ComparisonOperatorId,0) ComparisonOperatorId 
 	, ISNULL(dbProcessTemplateFlowCondition.ProcessTemplateFlowConditionString,'') ConditionString
	, ISNULL(dbProcessTemplateFlowCondition.ProcessTemplateFlowConditionInt,0) ConditionInt
FROM dbProcessTemplateFlowCondition 
WHERE dbProcessTemplateFlowCondition.ProcessTemplateFlowId = @PId
ORDER BY Id
