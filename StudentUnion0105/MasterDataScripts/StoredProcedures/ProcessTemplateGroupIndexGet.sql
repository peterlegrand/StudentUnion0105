CREATE PROCEDURE ProcessTemplateGroupIndexGet (@LanguageId int)
AS
SELECT 
	dbProcessTemplateGroupLanguage.Id
	, ISNULL(dbProcessTemplateGroupLanguage.Name,'') Name
	, ISNULL(dbProcessTemplateGroupLanguage.Description,'') Description
	, ISNULL(dbProcessTemplateGroupLanguage.MouseOver,'') MouseOver
	, ISNULL(dbProcessTemplateGroupLanguage.MenuName,'') MenuName
FROM dbProcessTemplateGroupLanguage
WHERE dbProcessTemplateGroupLanguage.LanguageId = @LanguageId
ORDER BY dbProcessTemplateGroupLanguage.Name
