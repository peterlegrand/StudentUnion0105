CREATE PROCEDURE ProcessTemplateFieldLanguageIndexSelect (@Id int)
AS 
SELECT dbProcessTemplateFieldLanguage.Id
	, dbProcessTemplateField.Id
	, dbLanguage.LanguageName
	, dbProcessTemplateFieldLanguage.Name
	, dbProcessTemplateFieldLanguage.MouseOver
	, dbProcessTemplateFieldLanguage.MenuName
	, Creator.UserName Creator
	, Modifier.UserName Modifier
	, dbProcessTemplateFieldLanguage.CreatedDate
	, dbProcessTemplateFieldLanguage.ModifiedDate
FROM dbProcessTemplateField
JOIN dbProcessTemplateFieldLanguage
	ON dbProcessTemplateField.Id = dbProcessTemplateFieldLanguage.ProcessTemplateFieldId
JOIN dbLanguage
	ON dbLanguage.Id = dbProcessTemplateFieldLanguage.LanguageId
JOIN AspNetUsers Creator
	ON CAST( dbProcessTemplateFieldLanguage.CreatorId as nvarchar(450))= Creator.Id
JOIN AspNetUsers Modifier
	ON CAST( dbProcessTemplateFieldLanguage.CreatorId as nvarchar(450))= Modifier.Id
WHERE dbProcessTemplateFieldLanguage.ProcessTemplateFieldId = @Id
ORDER BY 
dbProcessTemplateFieldLanguage.Name




