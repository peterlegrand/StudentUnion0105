CREATE PROCEDURE ProcessTemplateGroupIndexGet (@LanguageId int)
AS
SELECT 
	dbProcessTemplateGroupLanguage.Id
	, dbProcessTemplateGroupLanguage.Name
	, dbProcessTemplateGroupLanguage.Description
	, dbProcessTemplateGroupLanguage.MouseOver
	, dbProcessTemplateGroupLanguage.MenuName
FROM dbProcessTemplateGroupLanguage
WHERE dbProcessTemplateGroupLanguage.LanguageId = @LanguageId
ORDER BY dbProcessTemplateGroupLanguage.Name
