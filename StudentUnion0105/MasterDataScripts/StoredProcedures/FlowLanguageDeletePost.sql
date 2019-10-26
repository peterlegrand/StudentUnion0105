CREATE PROCEDURE FlowLanguageDeletePost (@Id int)
AS
DELETE FROM dbProcessTemplateFlowLanguage 
WHERE dbProcessTemplateFlowLanguage.Id = @Id;
