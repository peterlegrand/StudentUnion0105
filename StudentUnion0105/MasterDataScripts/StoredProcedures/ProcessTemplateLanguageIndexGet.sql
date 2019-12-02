CREATE PROCEDURE ProcessTemplateLanguageIndexGet (@OId int)
AS
SELECT 
	dbProcessTemplateLanguage.Id LId
	, dbProcessTemplateLanguage.ProcessTemplateId OId
	, 0 PId
	, ISNULL(dbProcessTemplateLanguage.Name,'') Name
	, ISNULL(dbProcessTemplateLanguage.Description,'') Description
	, ISNULL(dbProcessTemplateLanguage.MouseOver,'') MouseOver
	, ISNULL(dbProcessTemplateLanguage.MenuName,'') MenuName
	, dbLanguage.Id LanguageId
	, ISNULL(dbLanguage.LanguageName,'') LanguageName
FROM dbProcessTemplateLanguage
JOIN dbLanguage 
	ON dbProcessTemplateLanguage.LanguageId = dbLanguage.Id
WHERE dbProcessTemplateLanguage.ProcessTemplateId = @OId
ORDER BY dbLanguage.LanguageName
