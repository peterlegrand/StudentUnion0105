CREATE PROCEDURE ProcessTemplateFlowConditionLanguageIndexGet (@OId int)
AS
SELECT 
	dbProcessTemplateFlowConditionLanguage.Id LId
	, dbProcessTemplateFlowConditionLanguage.FlowConditionId OId
	, dbProcessTemplateFlowCondition.ProcessTemplateFlowId PId
	, ISNULL(dbProcessTemplateFlowConditionLanguage.Name,'') Name
	, ISNULL(dbProcessTemplateFlowConditionLanguage.Description,'') Description
	, ISNULL(dbProcessTemplateFlowConditionLanguage.MouseOver,'') MouseOver
	, ISNULL(dbProcessTemplateFlowConditionLanguage.MenuName,'') MenuName
	, dbLanguage.Id LanguageId
	, ISNULL(dbLanguage.LanguageName,'') LanguageName
FROM dbProcessTemplateFlowConditionLanguage
JOIN dbLanguage 
	ON dbProcessTemplateFlowConditionLanguage.LanguageId = dbLanguage.Id
JOIN dbProcessTemplateFlowCondition
	ON dbProcessTemplateFlowCondition.Id = dbProcessTemplateFlowConditionLanguage.FlowConditionId
WHERE dbProcessTemplateFlowConditionLanguage.FlowConditionId = @OId
ORDER BY dbLanguage.LanguageName
