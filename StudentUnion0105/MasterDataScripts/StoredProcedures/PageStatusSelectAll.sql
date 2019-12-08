CREATE PROCEDURE [dbo].[PageStatusSelectAll] 
AS  
SELECT  
dbPageStatus.Id 
, ISNULL(dbPageStatus.Name,'') Name 
FROM dbPageStatus 
ORDER BY dbPageStatus.Name
