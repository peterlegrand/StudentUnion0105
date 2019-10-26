CREATE PROCEDURE ProcessTemplateFlowConditionLanguageIndexGet (@Id int)
AS
SELECT 
dbLanguage.LanguageName
	, dbProcessTemplateFlowConditionLanguage.Id
	, dbProcessTemplateFlowConditionLanguage.Name
	, dbProcessTemplateFlowConditionLanguage.Description
	, dbProcessTemplateFlowConditionLanguage.MouseOver
	, dbProcessTemplateFlowConditionLanguage.MenuName
FROM dbProcessTemplateFlowConditionLanguage
JOIN dbLanguage 
	ON dbProcessTemplateFlowConditionLanguage.LanguageId = dbLanguage.Id
WHERE dbProcessTemplateFlowConditionLanguage.FlowConditionId = @Id
ORDER BY dbLanguage.LanguageName
