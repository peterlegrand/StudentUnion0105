CREATE PROCEDURE Menu1LanguageIndexGet (@OId int)
AS
SELECT 
	 dbMenu1Language.Id LId
	, dbMenu1Language.Menu1Id OId
	, 0 PId
	, ISNULL(dbMenu1Language.MenuName,'') MenuName
	, ISNULL(dbMenu1Language.MouseOver,'') MouseOver
	, '' Description
	, '' Name
	, dbLanguage.Id LanguageId
	, ISNULL(dbLanguage.LanguageName,'') LanguageName
FROM dbMenu1Language
JOIN dbLanguage 
	ON dbMenu1Language.LanguageId = dbLanguage.Id
WHERE dbMenu1Language.Menu1Id = @OId
ORDER BY dbLanguage.LanguageName
