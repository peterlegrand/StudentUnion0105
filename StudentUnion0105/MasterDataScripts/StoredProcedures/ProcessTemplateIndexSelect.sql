CREATE PROCEDURE ProcessTemplateIndexSelect (@LanguageId int)
AS 
SELECT dbProcessTemplate.Id
	, dbProcessTemplateLanguage.LanguageId
	, dbProcessTemplateLanguage.Name
	, dbProcessTemplateLanguage.MouseOver
	, dbProcessTemplateLanguage.MenuName
	, dbProcessTemplateGroupLanguage.Name GroupName
	, Creator.UserName Creator
	, Modifier.UserName Modifier
	, dbProcessTemplate.CreatedDate
	, dbProcessTemplate.ModifiedDate
FROM dbProcessTemplate
JOIN dbProcessTemplateLanguage
	ON dbProcessTemplate.Id = dbProcessTemplateLanguage.ProcessTemplateId
JOIN dbProcessTemplateGroupLanguage
	ON dbProcessTemplate.ProcessTemplateGroupId = dbProcessTemplateGroupLanguage.Id
JOIN AspNetUsers Creator
	ON CAST( dbProcessTemplate.CreatorId as nvarchar(450))= Creator.Id
JOIN AspNetUsers Modifier
	ON CAST( dbProcessTemplate.CreatorId as nvarchar(450))= Modifier.Id
WHERE dbProcessTemplateLanguage.LanguageId = @LanguageId
ORDER BY 
dbProcessTemplateLanguage.Name


