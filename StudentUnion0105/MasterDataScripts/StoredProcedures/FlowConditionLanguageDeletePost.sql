CREATE PROCEDURE FlowConditionLanguageDeletePost (@Id int)
AS
DELETE FROM dbProcessTemplateFlowConditionLanguage 
WHERE dbProcessTemplateFlowConditionLanguage.Id = @Id;
