CREATE PROCEDURE ProcessTemplateFlowConditionCreateGetComparison  
AS  
SELECT  
dbComparison.Id 
, dbComparison.Name
FROM dbComparison 
ORDER BY dbComparison.Name 
