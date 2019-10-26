CREATE PROCEDURE ProcessTemplateFlowLanguageIndexGet (@Id int)
AS
SELECT 
dbLanguage.LanguageName
	, dbProcessTemplateFlowLanguage.Id
	, dbProcessTemplateFlowLanguage.Name
	, dbProcessTemplateFlowLanguage.Description
	, dbProcessTemplateFlowLanguage.MouseOver
	, dbProcessTemplateFlowLanguage.MenuName
FROM dbProcessTemplateFlowLanguage
JOIN dbLanguage 
	ON dbProcessTemplateFlowLanguage.LanguageId = dbLanguage.Id
WHERE dbProcessTemplateFlowLanguage.FlowId = @Id
ORDER BY dbLanguage.LanguageName
