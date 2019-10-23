CREATE PROCEDURE PageSectionTypeIndexSelect (@LanguageId int)
AS 
SELECT dbPageSectionType.Id
	, dbPageSectionTypeLanguage.LanguageId
	, dbPageSectionTypeLanguage.Name
	, dbPageSectionTypeLanguage.MouseOver
	, dbPageSectionTypeLanguage.MenuName
	, Creator.UserName Creator
	, Modifier.UserName Modifier
	, dbPageSectionType.CreatedDate
	, dbPageSectionType.ModifiedDate
FROM dbPageSectionType
JOIN dbPageSectionTypeLanguage
	ON dbPageSectionType.Id = dbPageSectionTypeLanguage.PageSectionTypeId
JOIN AspNetUsers Creator
	ON CAST( dbPageSectionType.CreatorId as nvarchar(450))= Creator.Id
JOIN AspNetUsers Modifier
	ON CAST( dbPageSectionType.CreatorId as nvarchar(450))= Modifier.Id
WHERE dbPageSectionTypeLanguage.LanguageId = @LanguageId
ORDER BY 
dbPageSectionTypeLanguage.Name




