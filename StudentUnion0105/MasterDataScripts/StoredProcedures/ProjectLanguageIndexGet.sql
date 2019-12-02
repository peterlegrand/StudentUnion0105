CREATE PROCEDURE ProjectLanguageIndexGet (@OId int)
AS
SELECT 
	dbProjectLanguage.Id LId
	, dbProjectLanguage.ProjectId OId
	, 0 PId
	, ISNULL(dbProjectLanguage.Name,'') Name
	, ISNULL(dbProjectLanguage.Description,'') Description
	, ISNULL(dbProjectLanguage.MouseOver,'') MouseOver
	, ISNULL(dbProjectLanguage.MenuName,'') MenuName
	, dbLanguage.Id LanguageId
	, ISNULL(dbLanguage.LanguageName,'') LanguageName
FROM dbProjectLanguage
JOIN dbLanguage 
	ON dbProjectLanguage.LanguageId = dbLanguage.Id
WHERE dbProjectLanguage.ProjectId = @OId
ORDER BY dbLanguage.LanguageName
