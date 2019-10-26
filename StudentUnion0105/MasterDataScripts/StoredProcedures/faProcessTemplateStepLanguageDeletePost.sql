CREATE PROCEDURE faProcessTemplateStepLanguageDeletePost (@Id int)
AS
DELETE FROM dbProcessTemplateStepLanguage 
WHERE dbProcessTemplateStepLanguage.Id = @Id;
