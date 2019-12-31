CREATE PROCEDURE Menu1 (@LanguageId int)
AS 
SELECT 
	dbMenu1.Id
	, dbMenu1.MenuTypeId
	, dbMenu1.ClassificationId
	, dbMenu1.Controller
	, dbMenu1.Action
	, dbMenu1.DestinationId
	, dbMenu1Language.MenuName
	, dbMenu1Language.MouseOver
FROM dbMenu1 
JOIN dbMenu1Language 
	ON dbMenu1.Id = dbMenu1Language.Menu1Id 
	WHERE LanguageId = @LanguageId
ORDER BY dbMenu1.Sequence
