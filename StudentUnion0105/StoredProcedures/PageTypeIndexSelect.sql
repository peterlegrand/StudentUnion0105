CREATE PROCEDURE PageTypeIndexSelect (@LanguageId int)
AS 
SELECT dbPageType.Id
	, dbPageTypeLanguage.LanguageId
	, dbPageTypeLanguage.Name
	, dbPageTypeLanguage.MouseOver
	, dbPageTypeLanguage.MenuName
	, Creator.UserName Creator
	, Modifier.UserName Modifier
	, dbPageType.CreatedDate
	, dbPageType.ModifiedDate
FROM dbPageType
JOIN dbPageTypeLanguage
	ON dbPageType.Id = dbPageTypeLanguage.PageTypeId
JOIN AspNetUsers Creator
	ON CAST( dbPageType.CreatorId as nvarchar(450))= Creator.Id
JOIN AspNetUsers Modifier
	ON CAST( dbPageType.CreatorId as nvarchar(450))= Modifier.Id
WHERE dbPageTypeLanguage.LanguageId = @LanguageId
ORDER BY 
dbPageTypeLanguage.Name




