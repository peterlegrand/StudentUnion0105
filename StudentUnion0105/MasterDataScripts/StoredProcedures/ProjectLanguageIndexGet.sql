CREATE PROCEDURE ProjectLanguageIndexGet (@Id int)
AS
SELECT 
dbLanguage.LanguageName
	, dbProjectLanguage.Id
	, dbProjectLanguage.Name
	, dbProjectLanguage.Description
	, dbProjectLanguage.MouseOver
	, dbProjectLanguage.MenuName
FROM dbProjectLanguage
JOIN dbLanguage 
	ON dbProjectLanguage.LanguageId = dbLanguage.Id
WHERE dbProjectLanguage.ProjectId = @Id
ORDER BY dbLanguage.LanguageName
