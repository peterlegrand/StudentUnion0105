CREATE PROCEDURE ContentTypeGroupEditGet (@LanguageId int, @Id int)
AS
SELECT
	dbContentTypeGroup.Id 
	, Creator.UserName Creator
	, dbContentTypeGroup.CreatedDate
	, Modifier.UserName Modifier
	, dbContentTypeGroup.ModifiedDate
	, dbContentTypeGroupLanguage.Id LId
	, dbContentTypeGroupLanguage.Name
	, dbContentTypeGroupLanguage.Description
	, dbContentTypeGroupLanguage.MouseOver
	, dbContentTypeGroupLanguage.MenuName
FROM dbContentTypeGroupLanguage
JOIN dbContentTypeGroup 
	ON dbContentTypeGroupLanguage.ContentTypeGroupId = dbContentTypeGroup.Id
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbContentTypeGroup.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbContentTypeGroup.ModifierId) = Modifier.Id
WHERE dbContentTypeGroupLanguage.LanguageId = @LanguageId
	AND dbContentTypeGroup.Id = @Id


