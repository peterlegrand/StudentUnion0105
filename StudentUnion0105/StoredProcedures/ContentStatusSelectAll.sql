CREATE PROCEDURE [dbo].[ContentStatusSelectAll] 
AS  
SELECT  
dbContentStatus.Id 
, ISNULL(dbContentStatus.ContentStatusName,'') Name 
FROM dbContentStatus 
ORDER BY dbContentStatus.ContentStatusName