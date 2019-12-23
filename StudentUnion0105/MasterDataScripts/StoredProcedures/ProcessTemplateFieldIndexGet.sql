CREATE PROCEDURE ProcessTemplateFieldIndexGet (@PId int, @LanguageId int)
AS
SELECT 
	dbProcessTemplateField.Id
	, dbProcessTemplateFieldLanguage.Name
	, dbProcessTemplateFieldLanguage.Description
	, dbProcessTemplateFieldLanguage.MouseOver
	, dbProcessTemplateFieldLanguage.MenuName
FROM dbProcessTemplateFieldLanguage
JOIN dbProcessTemplateField 
	ON dbProcessTemplateFieldLanguage.ProcessTemplateFieldId = dbProcessTemplateField.Id
WHERE dbProcessTemplateFieldLanguage.LanguageId = @LanguageId
	AND dbProcessTemplateField.ProcessTemplateId = @PId
ORDER BY 	dbProcessTemplateFieldLanguage.Name

