CREATE PROCEDURE ProcessTemplateFieldSelect
	(@PRocessTemplateFieldId int
	, @LanguageId int
	)
AS	
SELECT 
	dbProcessTemplateField.Id dbProcessTemplateFieldId
	, dbProcessTemplateField.ProcessTemplateId
	, dbProcessTemplateField.FieldMasterListId
	, dbProcessTemplateField.FieldDataTypeId
	, dbProcessTemplateFieldLanguage.Id dbProcessTemplateFieldLanguageId
	, dbProcessTemplateFieldLanguage.LanguageId
	, dbProcessTemplateFieldLanguage.ProcessTemplateFieldName
FROM dbProcessTemplateField
JOIN dbProcessTemplateFieldLanguage
	ON dbProcessTemplateField.Id = dbProcessTemplateFieldLanguage.ProcessTemplateFieldId
 WHERE dbProcessTemplateFieldLanguage.LanguageId = @LanguageId
	AND dbProcessTemplateField.Id = @PRocessTemplateFieldId