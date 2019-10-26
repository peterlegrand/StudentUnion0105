CREATE PROCEDURE ProcessTemplateStepDeletePost (@Id int)
AS
BEGIN TRANSACTION
DELETE FROM dbProcessTemplateStepLanguage 
WHERE dbProcessTemplateStepLanguage.StepId = @Id;

DELETE FROM dbProcessTemplateStep
WHERE dbProcessTemplateStep.Id = @Id
COMMIT TRANSACTION