CREATE PROCEDURE [dbo].[SecurityLevelSelectAll]  
AS  
SELECT  
dbSecurityLevel.Id Id 
, ISNULL(dbsecuritylevel.Name,'') Name 
FROM dbSecurityLevel 
ORDER BY dbSecurityLevel.Id 
