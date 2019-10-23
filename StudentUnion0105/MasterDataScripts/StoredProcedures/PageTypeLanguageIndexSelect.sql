CREATE PROCEDURE PageTypeLanguageIndexSelect (@Id int)
AS 
SELECT dbPageTypeLanguage.Id
	, dbPageType.Id
	, dbLanguage.LanguageName
	, dbPageTypeLanguage.Name
	, dbPageTypeLanguage.MouseOver
	, dbPageTypeLanguage.MenuName
	, Creator.UserName Creator
	, Modifier.UserName Modifier
	, dbPageTypeLanguage.CreatedDate
	, dbPageTypeLanguage.ModifiedDate
FROM dbPageType
JOIN dbPageTypeLanguage
	ON dbPageType.Id = dbPageTypeLanguage.PageTypeId
JOIN dbLanguage
	ON dbLanguage.Id = dbPageTypeLanguage.LanguageId
JOIN AspNetUsers Creator
	ON CAST( dbPageTypeLanguage.CreatorId as nvarchar(450))= Creator.Id
JOIN AspNetUsers Modifier
	ON CAST( dbPageTypeLanguage.CreatorId as nvarchar(450))= Modifier.Id
WHERE dbPageTypeLanguage.PageTypeId = @Id
ORDER BY 
dbPageTypeLanguage.Name




