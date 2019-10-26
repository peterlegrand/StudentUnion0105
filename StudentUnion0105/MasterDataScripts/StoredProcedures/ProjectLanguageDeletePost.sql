CREATE PROCEDURE ProjectLanguageDeletePost (@Id int)
AS
DELETE FROM dbProcessTemplateStepLanguage 
WHERE dbProcessTemplateStepLanguage.Id = @Id;
