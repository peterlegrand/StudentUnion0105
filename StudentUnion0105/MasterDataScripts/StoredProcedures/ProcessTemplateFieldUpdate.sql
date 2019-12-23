
CREATE PROCEDURE [dbo].[ProcessTemplateFieldUpdate]
	(@ProcessTemplateFieldId int
	, @FieldDataTypeId int
	, @FieldMasterListId int
	, @ProcessTemplateFieldLanguageID int
	, @Name nvarchar(max)
	, @Description nvarchar(max)
	, @MouseOver nvarchar(max)
	)
AS
BEGIN TRANSACTION 
 
	UPDATE 
		dbProcessTemplateField SET
		dbProcessTemplateField.ProcessTemplateFieldTypeId = @FieldDataTypeId
	WHERE dbProcessTemplateField.Id = @ProcessTemplateFieldId

	UPDATE dbProcessTemplateFieldLanguage SET
		dbProcessTemplateFieldLanguage.Name = @Name
		, dbProcessTemplateFieldLanguage.Description = @Description
		, dbProcessTemplateFieldLanguage.MouseOver = @MouseOver
		, dbProcessTemplateFieldLanguage.ModifiedDate = getdate()
	WHERE  dbProcessTemplateFieldLanguage.Id = @ProcessTemplateFieldLanguageID
COMMIT TRANSACTION 

