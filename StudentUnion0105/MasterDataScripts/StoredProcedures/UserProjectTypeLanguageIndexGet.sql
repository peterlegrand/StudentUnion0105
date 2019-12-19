CREATE PROCEDURE UserProjectTypeLanguageIndexGet (@OId int)
AS
SELECT 
	dbUserProjectTypeLanguage.Id LId
	, dbUserProjectTypeLanguage.TypeId OId
	, 0 PId
	, ISNULL(dbUserProjectTypeLanguage.Name,'') Name
	, ISNULL(dbUserProjectTypeLanguage.Description,'') Description
	, ISNULL(dbUserProjectTypeLanguage.MouseOver,'') MouseOver
	, ISNULL(dbUserProjectTypeLanguage.MenuName,'') MenuName
	, dbLanguage.Id LanguageId
	, ISNULL(dbLanguage.LanguageName,'') LanguageName
FROM dbUserProjectTypeLanguage
JOIN dbLanguage 
	ON dbUserProjectTypeLanguage.LanguageId = dbLanguage.Id
WHERE dbUserProjectTypeLanguage.TypeId = @OId
ORDER BY dbLanguage.LanguageName
