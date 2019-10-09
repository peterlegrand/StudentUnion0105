CREATE PROCEDURE [DataTypeSelectAll] 
AS  
SELECT  
dbDataType.Id Id 
, ISNULL(dbDataType.DataTypeName,'') Name 
FROM dbDataType 
ORDER BY dbDataType.DataTypeName
