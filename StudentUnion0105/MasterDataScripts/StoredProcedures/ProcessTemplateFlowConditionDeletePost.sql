CREATE PROCEDURE ProcessTemplateFlowConditionDeletePost (@Id int)
AS
BEGIN TRANSACTION
DELETE FROM dbProcessTemplateFlowConditionLanguage 
WHERE dbProcessTemplateFlowConditionLanguage.FlowConditionId = @Id;

DELETE FROM dbProcessTemplateFlowCondition
WHERE dbProcessTemplateFlowCondition.Id = @Id
COMMIT TRANSACTION