CREATE PROCEDURE [dbo].[GetContentStatus] 
AS  
SELECT  
dbContentStatus.Id 
, ISNULL(dbContentStatus.ContentStatusName,'') Name 
FROM dbContentStatus 
ORDER BY dbContentStatus.ContentStatusName