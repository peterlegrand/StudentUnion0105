CREATE PROCEDURE ProjectLanguageIndexGet (@Id int)
AS
SELECT 
dbLanguage.LanguageName
	, dbProjectLanguage.Id LId
	, dbProjectLanguage.Name
	, dbProjectLanguage.Description
	, dbProjectLanguage.MouseOver
	, dbProjectLanguage.MenuName
	, dbProjectLanguage.ProjectId OId
	, 0 PId
FROM dbProjectLanguage
JOIN dbLanguage 
	ON dbProjectLanguage.LanguageId = dbLanguage.Id
WHERE dbProjectLanguage.ProjectId = @Id
ORDER BY dbLanguage.LanguageName
