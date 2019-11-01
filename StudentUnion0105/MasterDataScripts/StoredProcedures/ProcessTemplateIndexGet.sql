CREATE PROCEDURE ProcessTemplateIndexGet (@LanguageId int)
AS
SELECT 
	dbProcessTemplateLanguage.Id
	, ISNULL(dbProcessTemplateLanguage.Name,'') Name
	, ISNULL(dbProcessTemplateLanguage.Description,'') Description
	, ISNULL(dbProcessTemplateLanguage.MouseOver,'') MouseOver
	, ISNULL(dbProcessTemplateLanguage.MenuName,'') MenuName
FROM dbProcessTemplateLanguage
WHERE dbProcessTemplateLanguage.LanguageId = @LanguageId
ORDER BY dbProcessTemplateLanguage.Name
