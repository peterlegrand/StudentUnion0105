CREATE PROCEDURE Menu2LanguageIndexGet (@OId int)
AS
SELECT 
	 dbMenu2Language.Id LId
	, dbMenu2Language.Menu2Id OId
	, 0 PId
	, ISNULL(dbMenu2Language.MenuName,'') MenuName
	, ISNULL(dbMenu2Language.MouseOver,'') MouseOver
	, dbLanguage.Id LanguageId
	, ISNULL(dbLanguage.LanguageName,'') LanguageName
FROM dbMenu2Language
JOIN dbLanguage 
	ON dbMenu2Language.LanguageId = dbLanguage.Id
WHERE dbMenu2Language.Menu2Id = @OId
ORDER BY dbLanguage.LanguageName
