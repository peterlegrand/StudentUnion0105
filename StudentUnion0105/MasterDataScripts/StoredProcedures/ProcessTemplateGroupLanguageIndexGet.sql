CREATE PROCEDURE ProcessTemplateGroupLanguageIndexGet (@OId int)
AS
SELECT 
	dbProcessTemplateGroupLanguage.Id LId
	, dbProcessTemplateGroupLanguage.ProcessTemplateGroupId OId
	, 0 PId 
	, ISNULL(dbProcessTemplateGroupLanguage.Name,'') Name
	, ISNULL(dbProcessTemplateGroupLanguage.Description,'') Description
	, ISNULL(dbProcessTemplateGroupLanguage.MouseOver,'') MouseOver
	, ISNULL(dbProcessTemplateGroupLanguage.MenuName,'') MenuName
	, dbLanguage.Id LanguageId
	, ISNULL(dbLanguage.LanguageName,'') LanguageName
FROM dbProcessTemplateGroupLanguage
JOIN dbLanguage 
	ON dbProcessTemplateGroupLanguage.LanguageId = dbLanguage.Id
WHERE dbProcessTemplateGroupLanguage.ProcessTemplateGroupId = @OId
ORDER BY dbLanguage.LanguageName
