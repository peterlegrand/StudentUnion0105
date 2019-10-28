CREATE PROCEDURE ProcessTemplateStepLanguageDeletePost (@Id int)
AS
DELETE FROM dbProcessTemplateStepLanguage 
WHERE dbProcessTemplateStepLanguage.Id = @Id;
