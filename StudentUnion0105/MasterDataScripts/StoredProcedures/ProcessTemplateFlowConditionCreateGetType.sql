CREATE PROCEDURE [dbo].[ProcessTemplateFlowConditionCreateGetType]  
AS  
SELECT  
dbProcessTemplateFlowConditionType.Id 
, dbProcessTemplateFlowConditionType.Name
FROM dbProcessTemplateFlowConditionType 
ORDER BY dbProcessTemplateFlowConditionType.Name 
