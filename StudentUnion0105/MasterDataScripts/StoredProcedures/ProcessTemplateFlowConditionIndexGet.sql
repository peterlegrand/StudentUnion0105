CREATE PROCEDURE ProcessTemplateFlowConditionIndexGet (@LanguageId int, @PId int)
AS
SELECT 
	dbProcessTemplateFlowConditionLanguage.Id
	, ISNULL(dbProcessTemplateFlowConditionLanguage.Name , '') Name
	, ISNULL(dbProcessTemplateFlowConditionLanguage.Description, '') Description
	, ISNULL(dbProcessTemplateFlowConditionLanguage.MouseOver, '') MouseOver
	, ISNULL(dbProcessTemplateFlowConditionLanguage.MenuName, '') MenuName
FROM dbProcessTemplateFlowConditionLanguage
JOIN dbProcessTemplateFlowCondition
	ON dbProcessTemplateFlowConditionLanguage.FlowConditionId = dbProcessTemplateFlowCondition.Id
WHERE dbProcessTemplateFlowConditionLanguage.LanguageId = @LanguageId
	AND dbProcessTemplateFlowCondition.ProcessTemplateFlowId = @PId
ORDER BY dbProcessTemplateFlowCondition.Id
