CREATE PROCEDURE ProcessTemplateFieldTypeLanguageIndexGet (@Id int)
AS
SELECT 
dbLanguage.LanguageName
	, dbProcessTemplateFieldTypeLanguage.Id LId
	, dbProcessTemplateFieldTypeLanguage.Name
	, dbProcessTemplateFieldTypeLanguage.Description
	, dbProcessTemplateFieldTypeLanguage.MouseOver
	, dbProcessTemplateFieldTypeLanguage.MenuName
	, dbProcessTemplateFieldTypeLanguage.FieldTypeId OId
	, 0 PId
FROM dbProcessTemplateFieldTypeLanguage
JOIN dbLanguage 
	ON dbProcessTemplateFieldTypeLanguage.LanguageId = dbLanguage.Id
WHERE dbProcessTemplateFieldTypeLanguage.FieldTypeId = @Id
ORDER BY dbLanguage.LanguageName
