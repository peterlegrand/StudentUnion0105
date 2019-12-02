CREATE PROCEDURE ProcessTemplateFlowLanguageIndexGet (@OId int)
AS
SELECT 
	dbProcessTemplateFlowLanguage.Id LId
	, dbProcessTemplateFlowLanguage.FlowId OId
	, dbProcessTemplateFlow.ProcessTemplateId PId
	, ISNULL(dbProcessTemplateFlowLanguage.Name,'') Name
	, ISNULL(dbProcessTemplateFlowLanguage.Description,'') Description
	, ISNULL(dbProcessTemplateFlowLanguage.MouseOver,'') MouseOver
	, ISNULL(dbProcessTemplateFlowLanguage.MenuName,'') MenuName
	, dbLanguage.Id LanguageId
	, ISNULL(dbLanguage.LanguageName,'') LanguageName
FROM dbProcessTemplateFlowLanguage
JOIN dbLanguage 
	ON dbProcessTemplateFlowLanguage.LanguageId = dbLanguage.Id
JOIN dbProcessTemplateFlow
	ON dbProcessTemplateFlow.Id = dbProcessTemplateFlowLanguage.FlowId
WHERE dbProcessTemplateFlowLanguage.FlowId = @OId
ORDER BY dbLanguage.LanguageName
