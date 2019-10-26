CREATE PROCEDURE ProcessTemplateFlowIndexGet (@LanguageId int)
AS
SELECT 
	dbProcessTemplateFlowLanguage.Id
	, dbProcessTemplateFlowLanguage.Name
	, dbProcessTemplateFlowLanguage.Description
	, dbProcessTemplateFlowLanguage.MouseOver
	, dbProcessTemplateFlowLanguage.MenuName
FROM dbProcessTemplateFlowLanguage
WHERE dbProcessTemplateFlowLanguage.LanguageId = @LanguageId
ORDER BY dbProcessTemplateFlowLanguage.Name
