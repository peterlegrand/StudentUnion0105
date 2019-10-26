CREATE PROCEDURE PageLanguageEditGet (@Id int)
AS
SELECT
	dbPage.Id 
	, Creator.UserName Creator
	, dbPageLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbPageLanguage.ModifiedDate
	, dbPageLanguage.Id LId
	, dbPageLanguage.Name
	, dbPageLanguage.Description
	, dbPageLanguage.MouseOver
	, dbPageLanguage.MenuName
FROM dbPageLanguage
JOIN dbPage
	ON dbPage.Id = dbPageLanguage.PageId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbPage.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbPage.ModifierId) = Modifier.Id
WHERE dbPageLanguage.Id=@Id

