CREATE PROCEDURE [dbo].[GetProcessTemplateFlowConditionType]  
AS  
SELECT  
dbProcessTemplateFlowConditionType.Id 
, dbProcessTemplateFlowConditionType.ConditionTypeName
FROM dbProcessTemplateFlowConditionType 
ORDER BY dbProcessTemplateFlowConditionType.ConditionTypeName 
