CREATE PROCEDURE [GetMasterList] 
AS  
SELECT  
dbMasterList.Id Id 
, ISNULL(dbMasterList.Name,'') Name 
FROM dbMasterList 
ORDER BY dbMasterList.Sequence
