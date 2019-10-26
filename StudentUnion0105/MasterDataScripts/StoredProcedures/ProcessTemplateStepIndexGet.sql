CREATE PROCEDURE ProcessTemplateStepIndexGet (@LanguageId int)
AS
SELECT 
	dbProcessTemplateStepLanguage.Id
	, dbProcessTemplateStepLanguage.Name
	, dbProcessTemplateStepLanguage.Description
	, dbProcessTemplateStepLanguage.MouseOver
	, dbProcessTemplateStepLanguage.MenuName
FROM dbProcessTemplateStepLanguage
WHERE dbProcessTemplateStepLanguage.LanguageId = @LanguageId
ORDER BY dbProcessTemplateStepLanguage.Name
