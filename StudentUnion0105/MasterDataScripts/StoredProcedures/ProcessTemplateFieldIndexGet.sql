CREATE PROCEDURE ProcessTemplateFieldIndexGet (@LanguageId int)
AS
SELECT 
	dbProcessTemplateFieldLanguage.Id
	, dbProcessTemplateFieldLanguage.Name
	, dbProcessTemplateFieldLanguage.Description
	, dbProcessTemplateFieldLanguage.MouseOver
	, dbProcessTemplateFieldLanguage.MenuName
FROM dbProcessTemplateFieldLanguage
WHERE dbProcessTemplateFieldLanguage.LanguageId = @LanguageId
ORDER BY dbProcessTemplateFieldLanguage.Name
