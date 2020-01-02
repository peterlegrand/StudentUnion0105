CREATE PROCEDURE Menu1IndexGet (@LanguageId int)
AS
SELECT 
	dbMenu1Language.Menu1Id Id
	, dbMenu1Language.MouseOver
	, dbMenu1Language.MenuName
FROM dbMenu1Language
WHERE dbMenu1Language.LanguageId = @LanguageId
ORDER BY dbMenu1Language.Name