CREATE PROCEDURE ProcessTemplateFlowLanguageIndexGet (@Id int)
AS
SELECT 
dbLanguage.LanguageName
	, dbProcessTemplateFlowLanguage.Id LId
	, dbProcessTemplateFlowLanguage.Name
	, dbProcessTemplateFlowLanguage.Description
	, dbProcessTemplateFlowLanguage.MouseOver
	, dbProcessTemplateFlowLanguage.MenuName
	, dbProcessTemplateFlowLanguage.FlowId OId
	, dbProcessTemplateFlow.ProcessTemplateId PId
FROM dbProcessTemplateFlowLanguage
JOIN dbLanguage 
	ON dbProcessTemplateFlowLanguage.LanguageId = dbLanguage.Id
JOIN dbProcessTemplateFlow
	ON dbProcessTemplateFlow.Id = dbProcessTemplateFlowLanguage.FlowId
WHERE dbProcessTemplateFlowLanguage.FlowId = @Id
ORDER BY dbLanguage.LanguageName
