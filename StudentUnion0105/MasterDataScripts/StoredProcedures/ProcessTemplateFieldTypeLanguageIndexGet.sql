CREATE PROCEDURE ProcessTemplateFieldTypeLanguageIndexGet (@OId int)
AS
SELECT 
	dbProcessTemplateFieldTypeLanguage.Id LId
	, dbProcessTemplateFieldTypeLanguage.FieldTypeId OId
	, 0 PId
	, ISNULL(dbProcessTemplateFieldTypeLanguage.Name,'') Name
	, ISNULL(dbProcessTemplateFieldTypeLanguage.Description,'') Description
	, ISNULL(dbProcessTemplateFieldTypeLanguage.MouseOver,'') MouseOver
	, ISNULL(dbProcessTemplateFieldTypeLanguage.MenuName,'') MenuName
	, dbLanguage.Id LanguageId
	, ISNULL(dbLanguage.LanguageName,'') LanguageName
FROM dbProcessTemplateFieldTypeLanguage
JOIN dbLanguage 
	ON dbProcessTemplateFieldTypeLanguage.LanguageId = dbLanguage.Id
WHERE dbProcessTemplateFieldTypeLanguage.FieldTypeId = @OId
ORDER BY dbLanguage.LanguageName
