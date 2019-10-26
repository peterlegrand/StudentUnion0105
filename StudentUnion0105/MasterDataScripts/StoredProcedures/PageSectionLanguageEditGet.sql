CREATE PROCEDURE PageSectionLanguageEditGet (@Id int)
AS
SELECT
	dbPageSection.Id 
	, Creator.UserName Creator
	, dbPageSectionLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbPageSectionLanguage.ModifiedDate
	, dbPageSectionLanguage.Id LId
	, dbPageSectionLanguage.Name
	, dbPageSectionLanguage.Description
	, dbPageSectionLanguage.MouseOver
	, dbPageSectionLanguage.MenuName
FROM dbPageSectionLanguage
JOIN dbPageSection
	ON dbPageSection.Id = dbPageSectionLanguage.PageSectionId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbPageSectionLanguage.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbPageSectionLanguage.ModifierId) = Modifier.Id
WHERE dbPageSectionLanguage.Id=@Id

