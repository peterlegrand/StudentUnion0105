CREATE PROCEDURE FrontProcessIndexGetTemplateGroup (@LanguageId int)
AS
SELECT 
	dbProcessTemplateGroup.Id OId 
	, dbProcessTemplateGroupLanguage.Name
	, dbProcessTemplateGroupLanguage.Description
FROM dbProcessTemplateGroup
JOIN dbProcessTemplateGroupLanguage
	ON dbProcessTemplateGroup.Id = dbProcessTemplateGroupLanguage.ProcessTemplateGroupId
WHERE dbProcessTemplateGroupLanguage.LanguageId = @LanguageId
ORDER BY dbProcessTemplateGroupLanguage.Name