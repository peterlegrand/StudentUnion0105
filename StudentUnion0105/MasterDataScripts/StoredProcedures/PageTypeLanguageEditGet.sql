CREATE PROCEDURE PageTypeLanguageEditGet (@Id int)
AS
SELECT
	dbPageType.Id 
	, Creator.UserName Creator
	, dbPageTypeLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbPageTypeLanguage.ModifiedDate
	, dbPageTypeLanguage.Id LId
	, dbPageTypeLanguage.Name
	, dbPageTypeLanguage.Description
	, dbPageTypeLanguage.MouseOver
	, dbPageTypeLanguage.MenuName
FROM dbPageTypeLanguage
JOIN dbPageType
	ON dbPageType.Id = dbPageTypeLanguage.PageTypeId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbPageTypeLanguage.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbPageTypeLanguage.ModifierId) = Modifier.Id
WHERE dbPageTypeLanguage.Id=@Id

