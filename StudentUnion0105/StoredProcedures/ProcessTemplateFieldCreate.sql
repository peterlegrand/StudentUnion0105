CREATE PROCEDURE [dbo].[ProcessTemplateFieldCreate]
	(@ProcessTemplateId int
	, @FieldDataTypeId int
	, @FieldMasterListId int
	, @LanguageId int
	, @ProcessTemplateFieldName nvarchar(max)
	, @ProcessTemplateFieldDescription nvarchar(max)
	, @ProcessTemplateFieldMouseOver nvarchar(max)
	)
AS
BEGIN TRANSACTION 
 
	INSERT 
		dbProcessTemplateField (ProcessTemplateId, FieldDataTypeId, FieldMasterListID)
	VALUES (@ProcessTemplateId, @FieldDataTypeId,@FieldMasterListId);

	DECLARE @NewProcessTemplateFieldId int	= scope_identity();
	
	INSERT dbProcessTemplateFieldLanguage (
		ProcessTemplateFieldId
		, LanguageId
		, ProcessTemplateFieldName
		, ProcessTemplateFieldDescription
		, ProcessTemplateFieldMouseOver
		, CreatedDate
		, ModifiedDate
		)
	VALUES (
		@NewProcessTemplateFieldId
		, @LanguageId
		, @ProcessTemplateFieldName
		, @ProcessTemplateFieldDescription
		, @ProcessTemplateFieldMouseOver
		, getdate()
		, getdate()
	) 

	INSERT INTO dbProcessTemplateStepField (
		StepId
		, FieldId
		, StatusId) 
	SELECT Id 
		, @NewProcessTemplateFieldId
		, 1 
	FROM dbProcessTemplateStep 
	WHERE ProcessTemplateId = @ProcessTemplateId 

COMMIT TRANSACTION 



