CREATE PROCEDURE ProcessTemplateFieldTypeIndexGet (@LanguageId int)
AS
SELECT 
	dbProcessTemplateFieldTypeLanguage.Id
	, dbProcessTemplateFieldTypeLanguage.Name
	, dbProcessTemplateFieldTypeLanguage.Description
	, dbProcessTemplateFieldTypeLanguage.MouseOver
	, dbProcessTemplateFieldTypeLanguage.MenuName
FROM dbProcessTemplateFieldTypeLanguage
WHERE dbProcessTemplateFieldTypeLanguage.LanguageId = @LanguageId
ORDER BY dbProcessTemplateFieldTypeLanguage.Name
