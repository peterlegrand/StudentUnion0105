CREATE PROCEDURE PageSectionLanguageIndexSelect (@Id int)
AS 
SELECT dbPageSectionLanguage.Id
	, dbPageSection.Id
	, dbLanguage.LanguageName
	, dbPageSectionLanguage.Name
	, dbPageSectionLanguage.MouseOver
	, dbPageSectionLanguage.MenuName
	, Creator.UserName Creator
	, Modifier.UserName Modifier
	, dbPageSectionLanguage.CreatedDate
	, dbPageSectionLanguage.ModifiedDate
FROM dbPageSection
JOIN dbPageSectionLanguage
	ON dbPageSection.Id = dbPageSectionLanguage.PageSectionId
JOIN dbLanguage
	ON dbLanguage.Id = dbPageSectionLanguage.LanguageId
JOIN AspNetUsers Creator
	ON CAST( dbPageSectionLanguage.CreatorId as nvarchar(450))= Creator.Id
JOIN AspNetUsers Modifier
	ON CAST( dbPageSectionLanguage.CreatorId as nvarchar(450))= Modifier.Id
WHERE dbPageSectionLanguage.PageSectionId = @Id
ORDER BY 
dbPageSectionLanguage.Name




