CREATE PROCEDURE ProcessTemplateDeleteGet (@LanguageId int, @Id int)
AS
SELECT
	dbProcessTemplate.Id 
	, dbProcessTemplateGroupLanguage.Name ProcessTemplateGroup
	, Creator.UserName Creator
	, dbProcessTemplate.CreatedDate
	, Modifier.UserName Modifier
	, dbProcessTemplate.ModifiedDate
	, dbProcessTemplateLanguage.Id LId
	, dbProcessTemplateLanguage.Name
	, dbProcessTemplateLanguage.Description
	, dbProcessTemplateLanguage.MouseOver
	, dbProcessTemplateLanguage.MenuName
FROM dbProcessTemplateLanguage
JOIN dbProcessTemplate
	ON dbProcessTemplate.Id = dbProcessTemplateLanguage.ProcessTemplateId
JOIN dbProcessTemplateGroupLanguage
	ON dbProcessTemplate.ProcessTemplateGroupId = dbProcessTemplateGroupLanguage.ProcessTemplateGroupId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbProcessTemplate.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbProcessTemplate.ModifierId) = Modifier.Id
WHERE dbProcessTemplateLanguage.LanguageId = @LanguageId
	AND dbProcessTemplate.Id = @Id

