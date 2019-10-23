CREATE PROCEDURE [DataTypeSelectAll] 
AS  
SELECT  
dbDataType.Id Id 
, ISNULL(dbDataType.Name,'') Name 
FROM dbDataType 
ORDER BY dbDataType.Name
