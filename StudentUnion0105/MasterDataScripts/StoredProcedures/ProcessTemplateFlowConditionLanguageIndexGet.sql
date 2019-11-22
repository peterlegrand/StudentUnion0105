CREATE PROCEDURE ProcessTemplateFlowConditionLanguageIndexGet (@Id int)
AS
SELECT 
dbLanguage.LanguageName
	, dbProcessTemplateFlowConditionLanguage.Id LId
	, dbProcessTemplateFlowConditionLanguage.Name
	, dbProcessTemplateFlowConditionLanguage.Description
	, dbProcessTemplateFlowConditionLanguage.MouseOver
	, dbProcessTemplateFlowConditionLanguage.MenuName
	, dbProcessTemplateFlowConditionLanguage.FlowConditionId OId
	, dbProcessTemplateFlowCondition.ProcessTemplateFlowId PId
FROM dbProcessTemplateFlowConditionLanguage
JOIN dbLanguage 
	ON dbProcessTemplateFlowConditionLanguage.LanguageId = dbLanguage.Id
JOIN dbProcessTemplateFlowCondition
	ON dbProcessTemplateFlowCondition.Id = dbProcessTemplateFlowConditionLanguage.FlowConditionId
WHERE dbProcessTemplateFlowConditionLanguage.FlowConditionId = @Id
ORDER BY dbLanguage.LanguageName
