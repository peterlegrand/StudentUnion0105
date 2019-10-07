
CREATE PROCEDURE [dbo].[ProcessTemplateStepCreate]
	(@ProcessTemplateId int
	, @LanguageId int
	, @ProcessTemplateStepName nvarchar(max)
	, @ProcessTemplateStepDescription nvarchar(max)
	, @ProcessTemplateStepMouseOver nvarchar(max)
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
		, ProcessTemplateStepName
		, ProcessTemplateStepDescription
		, ProcessTemplateStepMouseOver
		, CreatedDate
		, ModifiedDate
		)
	VALUES (
		@NewProcessTemplateStepId
		, @LanguageId
		, @ProcessTemplateStepName
		, @ProcessTemplateStepDescription
		, @ProcessTemplateStepMouseOver
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

