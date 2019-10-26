CREATE PROCEDURE ProcessTemplateGroupLanguageIndexGet (@Id int)
AS
SELECT 
dbLanguage.LanguageName
	, dbProcessTemplateGroupLanguage.Id
	, dbProcessTemplateGroupLanguage.Name
	, dbProcessTemplateGroupLanguage.Description
	, dbProcessTemplateGroupLanguage.MouseOver
	, dbProcessTemplateGroupLanguage.MenuName
FROM dbProcessTemplateGroupLanguage
JOIN dbLanguage 
	ON dbProcessTemplateGroupLanguage.LanguageId = dbLanguage.Id
WHERE dbProcessTemplateGroupLanguage.ProcessTemplateGroupId = @Id
ORDER BY dbLanguage.LanguageName
