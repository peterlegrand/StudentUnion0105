
CREATE PROCEDURE [dbo].[ProcessTemplateStepCreate]
	(@ProcessTemplateId int
	, @LanguageId int
	, @Name nvarchar(max)
	, @Description nvarchar(max)
	, @MouseOver nvarchar(max)
	)
AS
BEGIN TRANSACTION 
 
	INSERT 
		dbProcessTemplateStep (ProcessTemplateId)
	VALUES (@ProcessTemplateId);

	DECLARE @NewProcessTemplateStepId int	= scope_identity();
	
	INSERT dbProcessTemplateStepLanguage (
		StepId
		, LanguageId
		, Name
		, Description
		, MouseOver
		, CreatedDate
		, ModifiedDate
		)
	VALUES (
		@NewProcessTemplateStepId
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
	SELECT 	 @NewProcessTemplateStepId
		, Id 
		, 1 
	FROM dbProcessTemplateField 
	WHERE ProcessTemplateId = @ProcessTemplateId 
COMMIT TRANSACTION 

