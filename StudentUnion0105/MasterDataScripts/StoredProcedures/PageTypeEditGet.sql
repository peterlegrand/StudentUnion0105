CREATE PROCEDURE PageTypeEditGet (@LanguageId int, @Id int)
AS
SELECT
	dbPageType.Id 
	, Creator.UserName Creator
	, dbPageType.CreatedDate
	, Modifier.UserName Modifier
	, dbPageType.ModifiedDate
	, dbPageTypeLanguage.Id LId
	, dbPageTypeLanguage.Name
	, dbPageTypeLanguage.Description
	, dbPageTypeLanguage.MouseOver
	, dbPageTypeLanguage.MenuName
FROM dbPageTypeLanguage
JOIN dbPageType 
	ON dbPageTypeLanguage.PageTypeId = dbPageType.Id
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbPageType.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbPageType.ModifierId) = Modifier.Id
WHERE dbPageTypeLanguage.LanguageId = @LanguageId
	AND dbPageType.Id = @Id

