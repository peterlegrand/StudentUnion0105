CREATE PROCEDURE [GetDataTypes] 
AS  
SELECT  
dbDataType.Id Id 
, ISNULL(dbDataType.DataTypeName,'') Name 
FROM dbDataType 
ORDER BY dbDataType.DataTypeName
