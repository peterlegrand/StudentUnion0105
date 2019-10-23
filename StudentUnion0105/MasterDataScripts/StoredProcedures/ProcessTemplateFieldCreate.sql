CREATE PROCEDURE [dbo].[ProcessTemplateFieldCreate]
	(@ProcessTemplateId int
	, @FieldDataTypeId int
	, @FieldMasterListId int
	, @LanguageId int
	, @Name nvarchar(max)
	, @Description nvarchar(max)
	, @MouseOver nvarchar(max)
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
		, Name
		, Description
		, MouseOver
		, CreatedDate
		, ModifiedDate
		)
	VALUES (
		@NewProcessTemplateFieldId
		, @LanguageId
		, @Name
		, @Description
		, @MouseOver
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



