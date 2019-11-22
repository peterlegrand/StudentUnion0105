CREATE PROCEDURE ProcessTemplateGroupLanguageIndexGet (@Id int)
AS
SELECT 
dbLanguage.LanguageName
	, dbProcessTemplateGroupLanguage.Id LId
	, dbProcessTemplateGroupLanguage.Name
	, dbProcessTemplateGroupLanguage.Description
	, dbProcessTemplateGroupLanguage.MouseOver
	, dbProcessTemplateGroupLanguage.MenuName
	, dbProcessTemplateGroupLanguage.ProcessTemplateGroupId OId
	, 0 PId 
FROM dbProcessTemplateGroupLanguage
JOIN dbLanguage 
	ON dbProcessTemplateGroupLanguage.LanguageId = dbLanguage.Id
WHERE dbProcessTemplateGroupLanguage.ProcessTemplateGroupId = @Id
ORDER BY dbLanguage.LanguageName
