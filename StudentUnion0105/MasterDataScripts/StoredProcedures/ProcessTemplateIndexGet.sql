CREATE PROCEDURE ProcessTemplateIndexGet (@LanguageId int)
AS
SELECT 
	dbProcessTemplateLanguage.Id
	, dbProcessTemplateLanguage.Name
	, dbProcessTemplateLanguage.Description
	, dbProcessTemplateLanguage.MouseOver
	, dbProcessTemplateLanguage.MenuName
FROM dbProcessTemplateLanguage
WHERE dbProcessTemplateLanguage.LanguageId = @LanguageId
ORDER BY dbProcessTemplateLanguage.Name
