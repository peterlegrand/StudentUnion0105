CREATE PROCEDURE [dbo].[GetProcessTemplateFlowConditionType]  
AS  
SELECT  
dbProcessTemplateFlowConditionType.Id 
, dbProcessTemplateFlowConditionType.Name
FROM dbProcessTemplateFlowConditionType 
ORDER BY dbProcessTemplateFlowConditionType.Name 
