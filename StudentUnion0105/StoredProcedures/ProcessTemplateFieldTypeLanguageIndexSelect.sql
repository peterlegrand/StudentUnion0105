CREATE PROCEDURE ProcessTemplateFieldTypeLanguageIndexSelect (@Id int)
AS 
SELECT dbProcessTemplateFieldTypeLanguage.Id
	, dbProcessTemplateFieldType.Id
	, dbLanguage.LanguageName
	, dbProcessTemplateFieldTypeLanguage.Name
	, dbProcessTemplateFieldTypeLanguage.MouseOver
	, dbProcessTemplateFieldTypeLanguage.MenuName
	, Creator.UserName Creator
	, Modifier.UserName Modifier
	, dbProcessTemplateFieldTypeLanguage.CreatedDate
	, dbProcessTemplateFieldTypeLanguage.ModifiedDate
FROM dbProcessTemplateFieldType
JOIN dbProcessTemplateFieldTypeLanguage
	ON dbProcessTemplateFieldType.Id = dbProcessTemplateFieldTypeLanguage.FieldTypeId
JOIN dbLanguage
	ON dbLanguage.Id = dbProcessTemplateFieldTypeLanguage.LanguageId
JOIN AspNetUsers Creator
	ON CAST( dbProcessTemplateFieldTypeLanguage.CreatorId as nvarchar(450))= Creator.Id
JOIN AspNetUsers Modifier
	ON CAST( dbProcessTemplateFieldTypeLanguage.CreatorId as nvarchar(450))= Modifier.Id
WHERE dbProcessTemplateFieldTypeLanguage.FieldTypeId = @Id
ORDER BY 
dbProcessTemplateFieldTypeLanguage.Name




