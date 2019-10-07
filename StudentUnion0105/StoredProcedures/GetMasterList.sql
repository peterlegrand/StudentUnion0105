CREATE PROCEDURE [GetMasterList] 
AS  
SELECT  
dbMasterList.Id Id 
, ISNULL(dbMasterList.MasterListName,'') Name 
FROM dbMasterList 
ORDER BY dbMasterList.Sequence
