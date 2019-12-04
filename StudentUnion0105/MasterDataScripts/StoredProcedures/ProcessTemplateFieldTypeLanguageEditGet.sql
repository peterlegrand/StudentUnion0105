CREATE PROCEDURE ProcessTemplateFieldTypeLanguageEditGet (@LId int)
AS
SELECT
	dbProcessTemplateFieldType.Id OId
	, Creator.UserName Creator
	, dbProcessTemplateFieldTypeLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbProcessTemplateFieldTypeLanguage.ModifiedDate
	, dbProcessTemplateFieldTypeLanguage.Id LId
	, ISNULL(dbProcessTemplateFieldTypeLanguage.Name,'') Name
	, ISNULL(dbProcessTemplateFieldTypeLanguage.Description,'') Description
	, ISNULL(dbProcessTemplateFieldTypeLanguage.MouseOver,'') MouseOver
	, ISNULL(dbProcessTemplateFieldTypeLanguage.MenuName,'') MenuName
	, ISNULL(dbLanguage.LanguageName Language
	, 0 PId
FROM dbProcessTemplateFieldTypeLanguage
JOIN dbProcessTemplateFieldType
	ON dbProcessTemplateFieldType.Id = dbProcessTemplateFieldTypeLanguage.FieldTypeId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbProcessTemplateFieldTypeLanguage.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbProcessTemplateFieldTypeLanguage.ModifierId) = Modifier.Id
JOIN dbLanguage
	ON dbLanguage.Id = dbClassificationLanguage.LanguageId
WHERE dbProcessTemplateFieldTypeLanguage.Id=@LId

