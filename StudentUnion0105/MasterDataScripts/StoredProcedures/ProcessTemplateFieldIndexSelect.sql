CREATE PROCEDURE ProcessTemplateFieldIndexSelect (@LanguageId int)
AS 
SELECT dbProcessTemplateField.Id
	, dbProcessTemplateFieldLanguage.LanguageId
	, dbProcessTemplateField.ProcessTemplateId
	, dbProcessTemplateFieldLanguage.Name
	, dbProcessTemplateFieldLanguage.MouseOver
	, dbProcessTemplateFieldLanguage.MenuName
FROM dbProcessTemplateField
JOIN dbProcessTemplateFieldLanguage
	ON dbProcessTemplateField.Id = dbProcessTemplateFieldLanguage.ProcessTemplateFieldId
WHERE dbProcessTemplateFieldLanguage.LanguageId = @LanguageId
ORDER BY 
dbProcessTemplateFieldLanguage.Name


