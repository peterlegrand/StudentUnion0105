CREATE PROCEDURE ProcessTemplateFieldLanguageIndexGet (@OId int)
AS
SELECT 
	dbProcessTemplateFieldLanguage.Id LId
	, dbProcessTemplateFieldLanguage.ProcessTemplateFieldId OId
	, dbProcessTemplateField.ProcessTemplateId PId
	, ISNULL(dbProcessTemplateFieldLanguage.Name,'') Name
	, ISNULL(dbProcessTemplateFieldLanguage.Description,'') Description
	, ISNULL(dbProcessTemplateFieldLanguage.MouseOver,'') MouseOver
	, ISNULL(dbProcessTemplateFieldLanguage.MenuName,'') MenuName
	, dbLanguage.Id LanguageId
	, ISNULL(dbLanguage.LanguageName,'') LanguageName
FROM dbProcessTemplateFieldLanguage
JOIN dbLanguage 
	ON dbProcessTemplateFieldLanguage.LanguageId = dbLanguage.Id
JOIN dbProcessTemplateField
	ON dbProcessTemplateField.Id = dbProcessTemplateFieldLanguage.ProcessTemplateFieldId
WHERE dbProcessTemplateFieldLanguage.ProcessTemplateFieldId = @OId
ORDER BY dbLanguage.LanguageName
