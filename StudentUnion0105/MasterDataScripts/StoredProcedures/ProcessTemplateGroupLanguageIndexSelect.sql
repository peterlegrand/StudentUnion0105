CREATE PROCEDURE ProcessTemplateGroupLanguageIndexSelect (@Id int)
AS 
SELECT dbProcessTemplateGroupLanguage.Id
	, dbProcessTemplateGroup.Id
	, dbLanguage.LanguageName
	, dbProcessTemplateGroupLanguage.Name
	, dbProcessTemplateGroupLanguage.MouseOver
	, dbProcessTemplateGroupLanguage.MenuName
	, Creator.UserName Creator
	, Modifier.UserName Modifier
	, dbProcessTemplateGroupLanguage.CreatedDate
	, dbProcessTemplateGroupLanguage.ModifiedDate
FROM dbProcessTemplateGroup
JOIN dbProcessTemplateGroupLanguage
	ON dbProcessTemplateGroup.Id = dbProcessTemplateGroupLanguage.ProcessTemplateGroupId
JOIN dbLanguage
	ON dbLanguage.Id = dbProcessTemplateGroupLanguage.LanguageId
JOIN AspNetUsers Creator
	ON CAST( dbProcessTemplateGroupLanguage.CreatorId as nvarchar(450))= Creator.Id
JOIN AspNetUsers Modifier
	ON CAST( dbProcessTemplateGroupLanguage.CreatorId as nvarchar(450))= Modifier.Id
WHERE dbProcessTemplateGroupLanguage.ProcessTemplateGroupId = @Id
ORDER BY 
dbProcessTemplateGroupLanguage.Name




