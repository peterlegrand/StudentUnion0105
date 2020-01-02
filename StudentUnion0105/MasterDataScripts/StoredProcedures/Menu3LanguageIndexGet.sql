CREATE PROCEDURE Menu3LanguageIndexGet (@OId int)
AS
SELECT 
	 dbMenu3Language.Id LId
	, dbMenu3Language.Menu3Id OId
	, 0 PId
	, ISNULL(dbMenu3Language.MenuName,'') MenuName
	, ISNULL(dbMenu3Language.MouseOver,'') MouseOver
	, dbLanguage.Id LanguageId
	, ISNULL(dbLanguage.LanguageName,'') LanguageName
FROM dbMenu3Language
JOIN dbLanguage 
	ON dbMenu3Language.LanguageId = dbLanguage.Id
WHERE dbMenu3Language.Menu3Id = @OId
ORDER BY dbLanguage.LanguageName
