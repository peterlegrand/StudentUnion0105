
CREATE PROCEDURE [dbo].[ProcessTemplateStepUpdate]
	(@StepId int
	, @ProcessTemplateStepLanguageID int
	, @Name nvarchar(max)
	, @Description nvarchar(max)
	, @MouseOver nvarchar(max)
	)
AS
BEGIN TRANSACTION 
 	UPDATE dbProcessTemplateStepLanguage SET
		dbProcessTemplateStepLanguage.Name = @Name
		, dbProcessTemplateStepLanguage.Description = @Description
		, dbProcessTemplateStepLanguage.MouseOver = @MouseOver
		, dbProcessTemplateStepLanguage.ModifiedDate = getdate()
	WHERE  dbProcessTemplateStepLanguage.Id = @ProcessTemplateStepLanguageID
COMMIT TRANSACTION 

GO


