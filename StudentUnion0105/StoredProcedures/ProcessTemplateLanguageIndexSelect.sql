CREATE PROCEDURE ProcessTemplateLanguageIndexSelect (@Id int)
AS 
SELECT dbProcessTemplateLanguage.Id
	, dbProcessTemplate.Id
	, dbLanguage.LanguageName
	, dbProcessTemplateLanguage.Name
	, dbProcessTemplateLanguage.MouseOver
	, dbProcessTemplateLanguage.MenuName
	, Creator.UserName Creator
	, Modifier.UserName Modifier
	, dbProcessTemplateLanguage.CreatedDate
	, dbProcessTemplateLanguage.ModifiedDate
FROM dbProcessTemplate
JOIN dbProcessTemplateLanguage
	ON dbProcessTemplate.Id = dbProcessTemplateLanguage.ProcessTemplateId
JOIN dbLanguage
	ON dbLanguage.Id = dbProcessTemplateLanguage.LanguageId
JOIN AspNetUsers Creator
	ON CAST( dbProcessTemplateLanguage.CreatorId as nvarchar(450))= Creator.Id
JOIN AspNetUsers Modifier
	ON CAST( dbProcessTemplateLanguage.CreatorId as nvarchar(450))= Modifier.Id
WHERE dbProcessTemplateLanguage.ProcessTemplateId = @Id
ORDER BY 
dbProcessTemplateLanguage.Name




