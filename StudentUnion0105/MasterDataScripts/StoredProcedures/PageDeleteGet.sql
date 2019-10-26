CREATE PROCEDURE PageDeleteGet (@LanguageId int, @Id int)
AS
SELECT
	dbPage.Id 
	, dbPageTypeLanguage.Name Type
	, dbPageStatus.Name Status
	, Creator.UserName Creator
	, dbPage.CreatedDate
	, Modifier.UserName Modifier
	, dbPage.ModifiedDate
	, dbPageLanguage.Id LId
	, dbPageLanguage.Name
	, dbPageLanguage.Description
	, dbPageLanguage.MouseOver
	, dbPageLanguage.MenuName
	, dbPageLanguage.Title
	, dbPageLanguage.PageDescription
FROM dbPageLanguage
JOIN dbPage
	ON dbPageLanguage.PageId = dbpage.Id
JOIN dbPageTypeLanguage 
	ON dbPageTypeLanguage.PageTypeId = dbPage.PageTypeId
JOIN dbPageStatus
	ON dbPageStatus.Id = dbpage.PageStatusId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbPage.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbPage.ModifierId) = Modifier.Id
WHERE dbPageLanguage.LanguageId = @LanguageId
	AND dbPage.Id = @Id

