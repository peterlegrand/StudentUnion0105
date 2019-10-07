
CREATE PROCEDURE [dbo].[ProcessTemplateFieldUpdate]
	(@ProcessTemplateFieldId int
	, @FieldDataTypeId int
	, @FieldMasterListId int
	, @ProcessTemplateFieldLanguageID int
	, @ProcessTemplateFieldName nvarchar(max)
	, @ProcessTemplateFieldDescription nvarchar(max)
	, @ProcessTemplateFieldMouseOver nvarchar(max)
	)
AS
BEGIN TRANSACTION 
 
	UPDATE 
		dbProcessTemplateField SET
		dbProcessTemplateField.FieldDataTypeId = @FieldDataTypeId
		, dbProcessTemplateField.FieldMasterListID = @FieldMasterListID 
	WHERE dbProcessTemplateField.Id = @ProcessTemplateFieldId

	UPDATE dbProcessTemplateFieldLanguage SET
		dbProcessTemplateFieldLanguage.ProcessTemplateFieldName = @ProcessTemplateFieldName
		, dbProcessTemplateFieldLanguage.ProcessTemplateFieldDescription = @ProcessTemplateFieldDescription
		, dbProcessTemplateFieldLanguage.ProcessTemplateFieldMouseOver = @ProcessTemplateFieldMouseOver
		, dbProcessTemplateFieldLanguage.ModifiedDate = getdate()
	WHERE  dbProcessTemplateFieldLanguage.Id = @ProcessTemplateFieldLanguageID
COMMIT TRANSACTION 

