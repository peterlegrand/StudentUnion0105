CREATE PROCEDURE ProcessTemplateFieldTypeDeleteGet (@LanguageId int, @Id int)
AS
SELECT
	dbProcessTemplateFieldType.Id 
	, Creator.UserName Creator
	, dbProcessTemplateFieldType.CreatedDate
	, Modifier.UserName Modifier
	, dbProcessTemplateFieldType.ModifiedDate
	, dbProcessTemplateFieldTypeLanguage.Id LId
	, dbProcessTemplateFieldTypeLanguage.Name
	, dbProcessTemplateFieldTypeLanguage.Description
	, dbProcessTemplateFieldTypeLanguage.MouseOver
	, dbProcessTemplateFieldTypeLanguage.MenuName
FROM dbProcessTemplateFieldTypeLanguage
JOIN dbProcessTemplateFieldType 
	ON dbProcessTemplateFieldTypeLanguage.FieldTypeId = dbProcessTemplateFieldType.Id
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbProcessTemplateFieldType.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbProcessTemplateFieldType.ModifierId) = Modifier.Id
WHERE dbProcessTemplateFieldTypeLanguage.LanguageId = @LanguageId
	AND dbProcessTemplateFieldType.Id = @Id

