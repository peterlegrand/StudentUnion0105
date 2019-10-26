CREATE PROCEDURE ProcessTemplateFieldTypeLanguageIndexGet (@Id int)
AS
SELECT 
dbLanguage.LanguageName
	, dbProcessTemplateFieldTypeLanguage.Id
	, dbProcessTemplateFieldTypeLanguage.Name
	, dbProcessTemplateFieldTypeLanguage.Description
	, dbProcessTemplateFieldTypeLanguage.MouseOver
	, dbProcessTemplateFieldTypeLanguage.MenuName
FROM dbProcessTemplateFieldTypeLanguage
JOIN dbLanguage 
	ON dbProcessTemplateFieldTypeLanguage.LanguageId = dbLanguage.Id
WHERE dbProcessTemplateFieldTypeLanguage.FieldTypeId = @Id
ORDER BY dbLanguage.LanguageName
