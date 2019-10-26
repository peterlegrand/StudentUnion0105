CREATE PROCEDURE ProcessTemplateGroupDeleteGet (@LanguageId int, @Id int)
AS
SELECT
	dbProcessTemplateGroup.Id 
	, dbProcessTemplateGroup.Sequence
	, Creator.UserName Creator
	, dbProcessTemplateGroup.CreatedDate
	, Modifier.UserName Modifier
	, dbProcessTemplateGroup.ModifiedDate
	, dbProcessTemplateGroupLanguage.Id LId
	, dbProcessTemplateGroupLanguage.Name
	, dbProcessTemplateGroupLanguage.Description
	, dbProcessTemplateGroupLanguage.MouseOver
	, dbProcessTemplateGroupLanguage.MenuName
FROM dbProcessTemplateGroupLanguage
JOIN dbProcessTemplateGroup
	ON dbProcessTemplateGroup.Id = dbProcessTemplateGroupLanguage.ProcessTemplateGroupId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbProcessTemplateGroup.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbProcessTemplateGroup.ModifierId) = Modifier.Id
WHERE dbProcessTemplateGroupLanguage.LanguageId = @LanguageId
	AND dbProcessTemplateGroup.Id = @Id

