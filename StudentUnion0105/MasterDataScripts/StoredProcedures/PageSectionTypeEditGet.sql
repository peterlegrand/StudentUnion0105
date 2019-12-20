CREATE PROCEDURE PageSectionTypeEditGet (@LanguageId int, @Id int)
AS
SELECT
	dbPageSectionType.Id OId
	, Creator.UserName Creator
	, dbPageSectionType.CreatedDate
	, Modifier.UserName Modifier
	, dbPageSectionType.ModifiedDate
	, dbPageSectionTypeLanguage.Id LId
	, ISNULL(dbPageSectionTypeLanguage.Name,'') Name
	, ISNULL(dbPageSectionTypeLanguage.Description,'') Description
	, ISNULL(dbPageSectionTypeLanguage.MouseOver,'') MouseOver
	, ISNULL(dbPageSectionTypeLanguage.MenuName,'') MenuName
	, dbPageSectionType.IndexSection
FROM dbPageSectionTypeLanguage
JOIN dbPageSectionType 
	ON dbPageSectionTypeLanguage.PageSectionTypeId = dbPageSectionType.Id
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbPageSectionType.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbPageSectionType.ModifierId) = Modifier.Id
WHERE dbPageSectionTypeLanguage.LanguageId = @LanguageId
	AND dbPageSectionType.Id = @Id



	SELECT * FROM dbPageSectionTypeLanguage
SELECT * FROM dbPageSectionType
