CREATE PROCEDURE ContentStatusList 
AS
SELECT 
	DbContentStatus.Id
	, DbContentStatus.Name 
FROM DbContentStatus 
ORDER BY DbContentStatus.Name