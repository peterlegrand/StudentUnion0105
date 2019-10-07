
CREATE PROCEDURE [dbo].[ProcessTemplateStepUpdate]
	(@StepId int
	, @ProcessTemplateStepLanguageID int
	, @ProcessTemplateStepName nvarchar(max)
	, @ProcessTemplateStepDescription nvarchar(max)
	, @ProcessTemplateStepMouseOver nvarchar(max)
	)
AS
BEGIN TRANSACTION 
 	UPDATE dbProcessTemplateStepLanguage SET
		dbProcessTemplateStepLanguage.ProcessTemplateStepName = @ProcessTemplateStepName
		, dbProcessTemplateStepLanguage.ProcessTemplateStepDescription = @ProcessTemplateStepDescription
		, dbProcessTemplateStepLanguage.ProcessTemplateStepMouseOver = @ProcessTemplateStepMouseOver
		, dbProcessTemplateStepLanguage.ModifiedDate = getdate()
	WHERE  dbProcessTemplateStepLanguage.Id = @ProcessTemplateStepLanguageID
COMMIT TRANSACTION 

GO


