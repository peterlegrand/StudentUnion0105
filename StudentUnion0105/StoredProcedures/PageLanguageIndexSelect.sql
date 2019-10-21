CREATE PROCEDURE PageLanguageIndexSelect (@Id int)
AS 
SELECT dbPageLanguage.Id
	, dbPage.Id
	, dbLanguage.LanguageName
	, dbPageLanguage.Name
	, dbPageLanguage.MouseOver
	, dbPageLanguage.MenuName
	, Creator.UserName Creator
	, Modifier.UserName Modifier
	, dbPage.CreatedDate
	, dbPage.ModifiedDate
FROM dbPage
JOIN dbPageLanguage
	ON dbPage.Id = dbPageLanguage.PageId
JOIN dbLanguage
	ON dbLanguage.Id = dbPageLanguage.LanguageId
JOIN AspNetUsers Creator
	ON CAST( dbPage.CreatorId as nvarchar(450))= Creator.Id
JOIN AspNetUsers Modifier
	ON CAST( dbPage.CreatorId as nvarchar(450))= Modifier.Id
WHERE dbPageLanguage.PageId = @Id
ORDER BY 
dbPageLanguage.Name




