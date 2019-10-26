CREATE PROCEDURE PageSectionTypeDeleteGet (@LanguageId int, @Id int)
AS
SELECT
	dbPageSectionType.Id 
	, Creator.UserName Creator
	, dbPageSectionType.CreatedDate
	, Modifier.UserName Modifier
	, dbPageSectionType.ModifiedDate
	, dbPageSectionTypeLanguage.Id LId
	, dbPageSectionTypeLanguage.Name
	, dbPageSectionTypeLanguage.Description
	, dbPageSectionTypeLanguage.MouseOver
	, dbPageSectionTypeLanguage.MenuName
FROM dbPageSectionTypeLanguage
JOIN dbPageSectionType 
	ON dbPageSectionTypeLanguage.PageSectionTypeId = dbPageSectionType.Id
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbPageSectionType.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbPageSectionType.ModifierId) = Modifier.Id
WHERE dbPageSectionTypeLanguage.LanguageId = @LanguageId
	AND dbPageSectionType.Id = @Id

