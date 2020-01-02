CREATE PROCEDURE Menu2IndexGet (@Id int, @LanguageId int)
AS
SELECT 
	dbMenu2.Id
	, dbMenu2Language.MenuName
	, dbMenu2Language.MouseOver
FROM dbMenu2Language
JOIN dbMenu2 
	ON dbMenu2Language.Menu2Id = dbMenu2.Id
WHERE dbMenu2Language.LanguageId = @LanguageId
	AND dbMenu2.ClassificationId = @Id
ORDER BY dbMenu2.Sequence
