CREATE PROCEDURE ProcessTemplateEditGet (@LanguageId int, @Id int)
AS
SELECT
	dbProcessTemplate.Id 
	, dbProcessTemplate.ProcessTemplateGroupId
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
	ON dbProcessTemplateLanguage.ProcessTemplateId = dbProcessTemplate.Id
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbProcessTemplate.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbProcessTemplate.ModifierId) = Modifier.Id
WHERE dbProcessTemplateLanguage.LanguageId = @LanguageId
	AND dbProcessTemplate.Id = @Id

