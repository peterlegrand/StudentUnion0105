CREATE PROCEDURE FrontProcessToDoIndex2GetForAndOr AS SELECT 
	 DbProcessTemplateFlowCondition.ProcessTemplateFlowId FlowId
	, DbProcessTemplateFlowCondition.Id ConditionId
	, DbProcessTemplateFlowCondition.ProcessTemplateConditionTypeId ConditionTypeId
	, ISNULL(DbProcessTemplateFlowCondition.ProcessTemplateFieldId ,0) ConditionFieldId
	, ISNULL(DbProcessTemplateFlowCondition.ComparisonOperatorId,0) ComparisonOperatorId
	, ISNULL(DbProcessTemplateFlowCondition.ProcessTemplateFlowConditionString,'') ConditionString
	, ISNULL(DbProcessTemplateFlowCondition.ProcessTemplateFlowConditionInt,0) ConditionInt
	, ISNULL(DbProcessTemplateFlowCondition.ProcessTemplateFlowConditionDate, '1990-01-01') ConditionDate
FROM DbProcessTemplateFlow
	JOIN DbProcessTemplateFlowCondition
	ON DbProcessTemplateFlow.Id = DbProcessTemplateFlowCondition.ProcessTemplateFlowId
ORDER BY DbProcessTemplateFlow.Id, DbProcessTemplateFlowCondition.Id


