CREATE PROCEDURE PageSectionTypeLanguageEditGet (@Id int)
AS
SELECT
	dbPageSectionType.Id 
	, Creator.UserName Creator
	, dbPageSectionTypeLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbPageSectionTypeLanguage.ModifiedDate
	, dbPageSectionTypeLanguage.Id LId
	, dbPageSectionTypeLanguage.Name
	, dbPageSectionTypeLanguage.Description
	, dbPageSectionTypeLanguage.MouseOver
	, dbPageSectionTypeLanguage.MenuName
FROM dbPageSectionTypeLanguage
JOIN dbPageSectionType
	ON dbPageSectionType.Id = dbPageSectionTypeLanguage.PageSectionTypeId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbPageSectionTypeLanguage.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbPageSectionTypeLanguage.ModifierId) = Modifier.Id
WHERE dbPageSectionTypeLanguage.Id=@Id

