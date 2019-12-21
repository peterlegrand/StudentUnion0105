CREATE PROCEDURE UserProjectTypeIndexGet (@LanguageId int)
AS
SELECT 
	dbUserProjectTypeLanguage.Id
	, dbUserProjectTypeLanguage.Name
	, dbUserProjectTypeLanguage.Description
	, dbUserProjectTypeLanguage.MouseOver
	, dbUserProjectTypeLanguage.MenuName
FROM dbUserProjectTypeLanguage
WHERE dbUserProjectTypeLanguage.LanguageId = @LanguageId
ORDER BY dbUserProjectTypeLanguage.Name
