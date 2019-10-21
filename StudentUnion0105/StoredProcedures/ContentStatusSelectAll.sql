CREATE PROCEDURE [dbo].[ContentStatusSelectAll] 
AS  
SELECT  
dbContentStatus.Id 
, ISNULL(dbContentStatus.Name,'') Name 
FROM dbContentStatus 
ORDER BY dbContentStatus.Name
