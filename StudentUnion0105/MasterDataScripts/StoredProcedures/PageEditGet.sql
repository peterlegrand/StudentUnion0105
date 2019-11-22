CREATE PROCEDURE PageEditGet (@LanguageId int, @Id int)
AS
SELECT
	dbPage.Id 
	, dbPage.PageStatusId
	, dbPage.PageTypeId
	, Creator.UserName Creator
	, dbPage.CreatedDate
	, Modifier.UserName Modifier
	, dbPage.ModifiedDate
	, dbPageLanguage.Id LId
	, dbPageLanguage.Name
	, dbPageLanguage.Description
	, dbPageLanguage.MouseOver
	, dbPageLanguage.MenuName
	, dbPageLanguage.TitleDescription
	, dbPageLanguage.TitleName
FROM dbPageLanguage
JOIN dbPage 
	ON dbPageLanguage.PageId = dbPage.Id
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbPage.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbPage.ModifierId) = Modifier.Id
WHERE dbPageLanguage.LanguageId = @LanguageId
	AND dbPage.Id = @Id

