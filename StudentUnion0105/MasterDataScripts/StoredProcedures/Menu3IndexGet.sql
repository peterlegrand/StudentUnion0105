CREATE PROCEDURE Menu3IndexGet (@Id int, @LanguageId int)
AS
SELECT 
	dbMenu3.Id
	, dbMenu3Language.MenuName
	, dbMenu3Language.MouseOver
FROM dbMenu3Language
JOIN dbMenu3 
	ON dbMenu3Language.Menu3Id = dbMenu3.Id
WHERE dbMenu3Language.LanguageId = @LanguageId
	AND dbMenu3.Menu2Id = @Id
ORDER BY dbMenu3.Sequence

