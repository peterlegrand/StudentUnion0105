CREATE PROCEDURE ProcessTemplateFieldTypeLanguageEditGet (@Id int)
AS
SELECT
	dbProcessTemplateFieldType.Id 
	, Creator.UserName Creator
	, dbProcessTemplateFieldTypeLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbProcessTemplateFieldTypeLanguage.ModifiedDate
	, dbProcessTemplateFieldTypeLanguage.Id LId
	, dbProcessTemplateFieldTypeLanguage.Name
	, dbProcessTemplateFieldTypeLanguage.Description
	, dbProcessTemplateFieldTypeLanguage.MouseOver
	, dbProcessTemplateFieldTypeLanguage.MenuName
FROM dbProcessTemplateFieldTypeLanguage
JOIN dbProcessTemplateFieldType
	ON dbProcessTemplateFieldType.Id = dbProcessTemplateFieldTypeLanguage.FieldTypeId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbProcessTemplateFieldTypeLanguage.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbProcessTemplateFieldTypeLanguage.ModifierId) = Modifier.Id
WHERE dbProcessTemplateFieldTypeLanguage.Id=@Id

